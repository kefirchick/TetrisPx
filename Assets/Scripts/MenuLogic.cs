using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLogic : MonoBehaviour
{
    public AudioSource chalkSound;
    public void Game1Start () {
        SceneManager.LoadScene("Game1");
    }

    public void QuitGame () {
        chalkSound.Play();
        Application.Quit();
    }

    public void toSettings() {
        SceneManager.LoadScene("Settings");
    }

    public void toMenu() {
        SceneManager.LoadScene("Menu");
    }
}
