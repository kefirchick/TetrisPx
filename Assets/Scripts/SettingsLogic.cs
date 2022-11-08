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

    void Start() {
        volumeSlider = volumeObject.GetComponent<Slider>();
        volumeSlider.value = PlayerPrefs.GetFloat("volumePref", 1f);
        lengthSlider = lengthObject.GetComponent<Slider>();
        lengthSlider.value = PlayerPrefs.GetFloat("lengthPref", 7f);
        shapeSlider = shapeObject.GetComponent<Slider>();
        shapeSlider.value = PlayerPrefs.GetFloat("shapePref", 0f);
    }

    public void OnVolumeSliderChanged(float value) {
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("volumePref", volumeSlider.value);
        float vol = Mathf.Round(volumeSlider.value * 100f);
        volumeText.text = "VOLUME: " + vol.ToString() + "%";
    }

    public void OnLengthSliderChanged(int value) {
        PlayerPrefs.SetFloat("lengthPref", lengthSlider.value);
        lengthText.text = "ROW LENGTH: " + lengthSlider.value.ToString();
    }

    public void OnShapeSliderChanged(int value) {
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

    public void backToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
