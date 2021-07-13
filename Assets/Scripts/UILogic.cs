using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILogic : MonoBehaviour
{

    public static UILogic instance;
    
    public Text timeLeftText;
    public Text scoreText;

    public float timeLeft = 60f;
    public int score = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        // Showing time and score on UI
        timeLeft -= Time.deltaTime;
        timeLeftText.text = Mathf.Round(timeLeft).ToString();
        if (timeLeft < 0)
        {
            PlayerPrefs.SetInt("YourScore", score);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void UpScore()
    {
        // See LineEraseLogic
        score += 10;
        timeLeft++;
        scoreText.text = score.ToString();
    }

    public void DownScore()
    {
        // See BoxTrapDestroy
        score -= 10;
        scoreText.text = score.ToString();
    }
}
