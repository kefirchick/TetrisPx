using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
    public Text yourScore;
    
    void Start() {
        yourScore.text = "Your score: " + PlayerPrefs.GetInt("YourScore").ToString();
    }
}
