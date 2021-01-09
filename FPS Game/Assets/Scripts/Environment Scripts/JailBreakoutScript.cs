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

    public CameraShake cameraShake;

    public Animator anim;

    public bool generatorOff;
    public bool inRoom1 = true;

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
        }

        if(cabel1.gameObject == null && cabel2.gameObject == null && inRoom1 == true)
        {
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
                generatorOff = false;

                inRoom1 = false;
                StartCoroutine(cameraShake.Shake(1f, 1.5f));
            }
        }
    }
}
