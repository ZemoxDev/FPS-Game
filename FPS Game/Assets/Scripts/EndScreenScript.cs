using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenScript : MonoBehaviour
{
    public GameObject reload;
    public GameObject timer;
    public GameObject crosshair;
    public GameObject endscreen;

    public float timer_ = 6f;
    public bool timerCheck = false;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartEndscreen();
            endscreen.SetActive(true);

            timerCheck = true;
        }
    }

    void Start()
    {
        endscreen.SetActive(false);
    }

    void Update()
    {
        if (timerCheck)
        {
            timer_ -= Time.deltaTime;
        }

        if (timer_ <= 0)
        {
            timerCheck = false;
            Restart();
        }
    }

    public void StartEndscreen()
    {
        reload.SetActive(false);
        timer.SetActive(false);
        crosshair.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("1stLevel");
    }
}
