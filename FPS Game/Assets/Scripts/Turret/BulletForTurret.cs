using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForTurret : MonoBehaviour
{
    public float movementSpeed = 45f;

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);

        Destroy(gameObject, 4f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
