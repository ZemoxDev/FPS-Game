using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image HealthBar;
    private float currentHealth;
    private float maxHealth = 100f;
    PlayerMovement player;

    void Start()
    {
        HealthBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        currentHealth = player.health;
        HealthBar.fillAmount = currentHealth / maxHealth;
    }
}
