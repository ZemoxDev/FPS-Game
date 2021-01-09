using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("1stLevel");
    }

    public void WaveMode()
    {
        SceneManager.LoadScene("WaveLevel");
    }
}
