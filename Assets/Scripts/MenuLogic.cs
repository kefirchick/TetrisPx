using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLogic : MonoBehaviour
{
    public GameObject volumeSlider;
    private Slider slider;
    public Text volumeText;

    void Start() {
        slider = volumeSlider.GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat("volumePref", 1f);
    }

    public void Game1Start ()
    {
        SceneManager.LoadScene("Game1");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void OnSliderChanged(float value) {
        AudioListener.volume = slider.value;
        PlayerPrefs.SetFloat("volumePref", slider.value);
        float vol = Mathf.Round(slider.value * 100f);
        volumeText.text = "VOLUME: " + vol.ToString() + "%";
        Debug.Log(PlayerPrefs.GetFloat("volumePref", 0f));
    }
}
