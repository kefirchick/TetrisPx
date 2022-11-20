using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RedLineTrigger : MonoBehaviour
{
    public Text deathClock;
    private Color deathClockColor;
    private Animation deathClockAnimation;
    private Animation redAnimation;
    private List<GameObject> currentCollisions = new List<GameObject>();
    private float time = 3f;

    void Start()
    {
        deathClockAnimation = deathClock.GetComponent<Animation>();
        redAnimation = GetComponent<Animation>();
        deathClockColor = deathClock.color;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        currentCollisions.Add(col.gameObject);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        currentCollisions.Remove(col.gameObject);
    }

    void Update()
    {
        if (currentCollisions.Count > 0)
        {
            time = time - Time.deltaTime;
            deathClockAnimation.Play();
            redAnimation.Play();
            deathClock.text = "Game over in: " + Mathf.Ceil(time).ToString();
        }
        else
        {
            time = 3f;
            redAnimation.Rewind();
            deathClockAnimation.Rewind();
        }

        if (time < 0f)
        {
            PlayerPrefs.SetInt("YourScore", UILogic.instance.score);
            SceneManager.LoadScene("GameOver");
        }
    }
}
