using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Animator anim;

    public GameObject target;
    public GameObject turret;
    private bool targetLocked;

    public float Distance_;

    public GameObject turretTopPart;
    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    public float fireTimer;
    private bool shotReady;

    void Start()
    {
        shotReady = true;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Distance_ = Vector3.Distance(target.transform.position, turret.transform.position);
        if (Distance_ < 30)
        {
            targetLocked = true;
        }

        if (Distance_ > 65)
        {
            targetLocked = false;
        }

        if (targetLocked)
        {
            anim.SetBool("shooting", true);
            turretTopPart.transform.LookAt(target.transform);
            turretTopPart.transform.Rotate(0, -180, 0);

            if(shotReady)
            {
                Shoot();
            }
        }

        if(!targetLocked)
        {
            anim.SetBool("shooting", false);
        }
    }

    void Shoot()
    {
        Transform _bullet = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        _bullet.transform.rotation = bulletSpawnPoint.transform.rotation;
        shotReady = false;
        StartCoroutine(FireRate());
    }

    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireTimer);
        shotReady = true;
    }
}
