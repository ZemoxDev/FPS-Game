using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingEnemy : MonoBehaviour
{
    public Transform Player;
    public NavMeshAgent enemy;

    PlayerMovement player;
    public float damage = 50f;

    public GameObject explosionEffect;

    public float explosionForce = 5f;
    public float radius = 2f;
    public float Distance_;

    public int explodingDistance = 3;
    public int seeingDistance = 200;


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (Distance_ < seeingDistance)
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

        player.BombDamage();
    }
}
