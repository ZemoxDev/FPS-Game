using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Manager : MonoBehaviour
{
    public string player_prefab;
    public Transform[] spawn_points;

    public void Spawn()
    {
        Transform spawn = spawn_points[Random.Range(0, spawn_points.Length)];
        PhotonNetwork.Instantiate(player_prefab, spawn.position, spawn.rotation);
    }

}
