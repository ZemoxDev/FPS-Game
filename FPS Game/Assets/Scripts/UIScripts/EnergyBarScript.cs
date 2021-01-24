using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarScript : MonoBehaviour
{
    private Image EnergyBar;
    private float currentEnergy;
    private float maxEnergy = 1000f;
    PlayerMovement player;

    void Start()
    {
        EnergyBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        currentEnergy = player.energy;
        EnergyBar.fillAmount = currentEnergy / maxEnergy;
    }
}
