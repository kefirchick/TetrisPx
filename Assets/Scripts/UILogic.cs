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
    public Text volumeText;
    public GameObject volumeSlider;
    private Slider slider;
    public GameObject canvasUI;
    public GameObject canvasPause;

    public float timeLeft = 60f;
    public int score = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        slider = volumeSlider.GetComponent<Slider>();
        slider.value = AudioListener.volume * 100f;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftText.text = "NEXT IN: " + Mathf.Ceil(timeLeft).ToString();
    }

    public void UpScore()
    {
        score += 5;
        timeLeft++;
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void DownScore()
    {
        score -= 2;
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void SetTimer(float spawnTime) {
        timeLeft = spawnTime;
    }

    public void Pause() {
        canvasUI.SetActive(false);
        canvasPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume() {
        canvasUI.SetActive(true);
        canvasPause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnSliderChanged(float value) {
        AudioListener.volume = slider.value;
        float vol = Mathf.Round(slider.value * 100f);
        volumeText.text = "VOLUME: " + vol.ToString() + "%";
    }
}
