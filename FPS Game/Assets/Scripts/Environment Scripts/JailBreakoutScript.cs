using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JailBreakoutScript : MonoBehaviour
{
    public GameObject cabel1;
    public GameObject cabel2;
    public GameObject light;
    public GameObject particle;
    public GameObject hologram1;
    public GameObject hologram2;

    public BoxCollider jailCollider;

    public PlayerMovement playerSpeed;

    public Animator anim;

    bool generatorOff;

    private void Update()
    {
        if(cabel1.gameObject == null)
        {
            light.SetActive(false);
        }

        if(cabel2.gameObject == null)
        {
            particle.SetActive(false);
            hologram1.SetActive(false);
            hologram2.SetActive(false);

            generatorOff = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (playerSpeed.currentSpeed >= 15f && generatorOff == true)
            {
                anim.SetBool("breakout", true);
                jailCollider.isTrigger = true;
            }
        }
    }
}
