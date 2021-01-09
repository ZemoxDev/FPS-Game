using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoraFollowScript : MonoBehaviour
{
    public GameObject player;
    public Transform playerTransform;
    public float targetDistance;
    public float allowedDistance = 5;
    public float followSpeed;
    public RaycastHit Shot;

    void Update()
    {
        transform.LookAt(player.transform);
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            targetDistance = Shot.distance;
            if(targetDistance >= allowedDistance)
            {
                followSpeed = 0.1f;
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, followSpeed);
            }
            else
            {
                followSpeed = 0; 
            }
        }
    }
}
