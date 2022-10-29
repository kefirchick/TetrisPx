using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedLineTrigger : MonoBehaviour
{
    private List<GameObject> currentCollisions = new List<GameObject>();
    private float time = 3f;

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
        time = (currentCollisions.Count > 0) ? time - Time.deltaTime : 3f;
        if (time < 0f)
        {
            PlayerPrefs.SetInt("YourScore", UILogic.instance.score);
            SceneManager.LoadScene("GameOver");
        }
    }
}
