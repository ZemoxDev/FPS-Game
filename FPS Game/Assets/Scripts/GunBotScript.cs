using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GunBotScript : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking 
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public GameObject shootingPoint1;
    public GameObject shootingPoint2;
    public GameObject shootingPoint3;
    public GameObject shootingPoint4;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private Animator anim;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

        anim.SetBool("shooting", false);
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }

        anim.SetBool("shooting", false);
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        anim.SetBool("shooting", false);
    }

    private void AttackPlayer()
    {
        Vector3 targetPostition = new Vector3(player.position.x, this.transform.position.y, player.position.z);
        this.transform.LookAt(targetPostition);

        agent.SetDestination(transform.position);

        if (!alreadyAttacked)
        {
            Rigidbody rb =  Instantiate(projectile, shootingPoint1.transform.position, shootingPoint1.transform.rotation).GetComponent<Rigidbody>();
            Rigidbody rb2 = Instantiate(projectile, shootingPoint2.transform.position, shootingPoint2.transform.rotation).GetComponent<Rigidbody>();
            Rigidbody rb3 = Instantiate(projectile, shootingPoint3.transform.position, shootingPoint3.transform.rotation).GetComponent<Rigidbody>();
            Rigidbody rb4 = Instantiate(projectile, shootingPoint4.transform.position, shootingPoint4.transform.rotation).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 20f, ForceMode.Impulse);
            rb.AddForce(transform.up * -2f, ForceMode.Impulse);

            rb2.AddForce(transform.forward * 20f, ForceMode.Impulse);
            rb2.AddForce(transform.up * -2f, ForceMode.Impulse);

            rb3.AddForce(transform.forward * 20f, ForceMode.Impulse);
            rb3.AddForce(transform.up * -2f, ForceMode.Impulse);

            rb4.AddForce(transform.forward * 20f, ForceMode.Impulse);
            rb4.AddForce(transform.up * -2f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

            anim.SetBool("shooting", true);
        }

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
