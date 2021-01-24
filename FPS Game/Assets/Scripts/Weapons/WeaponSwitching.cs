using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    private AK47Script weaponScript;

    void Start()
    {
        SelectedWeapon();
    }

    void Update()
    {
        weaponScript = FindObjectOfType<AK47Script>();

        int previousSelectedWeapon = selectedWeapon;

        if(Input.GetKeyDown(KeyCode.Alpha1) && transform.childCount >= 1)
        {
            if(weaponScript.isReloading == false)
            {
                selectedWeapon = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            if (weaponScript.isReloading == false)
            {
                selectedWeapon = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            if (weaponScript.isReloading == false)
            {
                selectedWeapon = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            if (weaponScript.isReloading == false)
            {
                selectedWeapon = 3;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 5)
        {
            if (weaponScript.isReloading == false)
            {
                selectedWeapon = 4;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha6) && transform.childCount >= 6)
        {
            if (weaponScript.isReloading == false)
            {
                selectedWeapon = 5;
            }
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectedWeapon();
        }
    }

    void SelectedWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
