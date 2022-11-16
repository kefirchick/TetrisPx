using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsLogic : MonoBehaviour
{
    public GameObject volumeObject;
    private Slider volumeSlider;
    public Text volumeText;
    public GameObject lengthObject;
    private Slider lengthSlider;
    public Text lengthText;
    public GameObject shapeObject;
    private Slider shapeSlider;
    public Text shapeText;
    public GameObject gyroObject;
    private Toggle gyroToggle;
    public Text gyroText;
    public AudioSource chalkSound;

    void Start() {
        volumeSlider = volumeObject.GetComponent<Slider>();
        volumeSlider.value = PlayerPrefs.GetFloat("volumePref", 1f);
        lengthSlider = lengthObject.GetComponent<Slider>();
        lengthSlider.value = PlayerPrefs.GetFloat("lengthPref", 7f);
        shapeSlider = shapeObject.GetComponent<Slider>();
        shapeSlider.value = PlayerPrefs.GetFloat("shapePref", 0f);
        gyroToggle = gyroObject.GetComponent<Toggle>();
        gyroToggle.isOn = (PlayerPrefs.GetInt("gyroPref", 1) == 1) ? true : false;
    }

    public void OnVolumeSliderChanged(float value) {
        if (!chalkSound.isPlaying) chalkSound.Play();
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("volumePref", volumeSlider.value);
        float vol = Mathf.Round(volumeSlider.value * 100f);
        volumeText.text = "VOLUME: " + vol.ToString() + "%";
    }

    public void OnLengthSliderChanged(int value) {
        if (!chalkSound.isPlaying) chalkSound.Play();
        PlayerPrefs.SetFloat("lengthPref", lengthSlider.value);
        lengthText.text = "ROW LENGTH: " + lengthSlider.value.ToString();
    }

    public void OnShapeSliderChanged(int value) {
        if (!chalkSound.isPlaying) chalkSound.Play();
        PlayerPrefs.SetFloat("shapePref", shapeSlider.value);
        switch (shapeSlider.value) {
            case 0:
                shapeText.text = "Blocks shape: Square only";
                break;
            case 1:
                shapeText.text = "Blocks shape: Square and round";
                break;
            case 2:
                shapeText.text = "Blocks shape: Round only";
                break;
        }
    }

    public void onToggle(bool value) {
        chalkSound.Play();
        if (gyroToggle.isOn) {
            gyroText.text = "Gyroscop on";
            PlayerPrefs.SetInt("gyroPref", 1);
        } else {
            gyroText.text = "Gyroscop off";
            PlayerPrefs.SetInt("gyroPref", 0);
        };
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
