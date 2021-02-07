using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{

    void Update()
    {
        Destroy(gameObject, 1.5f);
    }
}
