using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public AK47Script gunScript;

    public float distance = 10f;
    public Transform equipPosition;
    GameObject currentWeapon;

    bool canGrab;

    private void Start()
    {
        gunScript.enabled = false;
    }

    void Update()
    {
        CheckGrab();

        if(canGrab)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("You can grab the tool");
                PickUp();
            }
        }
    }

    private void CheckGrab()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "CanGrab")
            {
                Debug.Log("You can grab the tool");
                currentWeapon = hit.transform.gameObject;
                canGrab = true;
            }
        }
        else
            canGrab = false;
    }

    private void PickUp()
    {
        currentWeapon.transform.position = equipPosition.position;
        currentWeapon.transform.parent = equipPosition;

        gunScript.enabled = true;

        Debug.Log("Picked it up");
    }
}