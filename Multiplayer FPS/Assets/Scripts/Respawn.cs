using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        player.transform.position = respawnPoint.transform.position;
        Physics.SyncTransforms();
    }
}