using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;

    void Start()
    {
        SelectedWeapon();
    }
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetKeyDown(KeyCode.Alpha9) && transform.childCount >= 1)
        {
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectedWeapon();
        }
    }

    void SelectedWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
