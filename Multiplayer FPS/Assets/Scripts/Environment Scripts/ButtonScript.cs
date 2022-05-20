using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject player;
    public GameObject button;
    public float distance_;
    public GameObject buttonText;
    public BoxCollider bridgeCollider;
    public GameObject nearThePit;

    public Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        distance_ = Vector3.Distance(player.transform.position, button.transform.position);
        if (distance_ < 3)
        {
            buttonText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("startBridge", true);
                bridgeCollider.isTrigger = true;
                Destroy(nearThePit);
            }
        }
        if (distance_ > 5)
        {
            buttonText.SetActive(false);
        }
    }
}
