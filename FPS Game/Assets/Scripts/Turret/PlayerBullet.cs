using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float movementSpeed = 15f;
    Target target;

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);

        Destroy(gameObject, 4f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Target>().Die();
        }
    }
}
