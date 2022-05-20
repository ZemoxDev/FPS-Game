using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorScreenStart : MonoBehaviour
{
    private void Awake()
    {
        AudioListener.volume = 1f;
    }

    public void WaveLevel()
    {
        SceneManager.LoadScene("WaveLevelSelector");
    }

    public void Multiplayer()
    {
        SceneManager.LoadScene("Multiplayer");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("SelectScreen");
    }
         
    public void Quit()
    {
        Application.Quit();
    }
}
