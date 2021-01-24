using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Animator anim;

    public GameObject target;
    public GameObject turret;
    public GameObject turretGun;
    private bool targetLocked;

    public float Distance_;

    public GameObject turretTopPart;
    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    public float fireTimer;
    private bool shotReady;

    public int seeingDistance = 30;
    public int disappearingDistance = 65;

    void Start()
    {
        shotReady = true;
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Distance_ = Vector3.Distance(target.transform.position, turret.transform.position);
        if (Distance_ < seeingDistance)
        {
            targetLocked = true;
        }

        if (Distance_ > disappearingDistance)
        {
            targetLocked = false;
        }

        if (targetLocked)
        {
            anim.SetBool("shooting", true);

            Vector3 targetPostition = new Vector3(target.transform.position.x, turretTopPart.transform.position.y, target.transform.position.z);                  
            turretTopPart.transform.LookAt(targetPostition);
            turretTopPart.transform.Rotate(0, -180, 0);
            turretGun.transform.LookAt(target.transform);
            turretGun.transform.Rotate(2, -180, 0);

            if (shotReady)
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
