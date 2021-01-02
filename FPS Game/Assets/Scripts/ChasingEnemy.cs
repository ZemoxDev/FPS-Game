using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingEnemy : MonoBehaviour
{
    public Transform Player;
    public NavMeshAgent enemy;

    [SerializeField] private Transform respawnPoint;

    public GameObject explosionEffect;

    public float explosionForce = 5f;
    public float radius = 2f;
    public float Distance_;

    void Update()
    {
        if(Distance_ < 18)
        {
            enemy.SetDestination(Player.position);
        }

        Distance_ = Vector3.Distance(Player.transform.position, enemy.transform.position);
        if(Distance_ < 3)
        {
            Explode();
        }
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider near in colliders)
        {
            Rigidbody rigB = near.GetComponent<Rigidbody>();

            if (rigB != null)
                rigB.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse);
        }

        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Debug.Log("Player Damaged");

        Player.transform.position = respawnPoint.transform.position;
        Physics.SyncTransforms();
    }
}
