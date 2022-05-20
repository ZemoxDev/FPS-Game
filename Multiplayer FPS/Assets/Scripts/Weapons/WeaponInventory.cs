using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    private GameObject weaponInvenotry;
    public GameObject weaponHolder;

    public GameObject StarterPistol;
    public GameObject Handgun;
    public GameObject Handgun2;
    public GameObject SMG;
    public GameObject MP7;
    public GameObject Ak47;
    public GameObject OneShooterGun;
    public GameObject Shotgun;
    public GameObject M16;
    public GameObject M82;
    public GameObject LMG;

    void Start()
    {
        if(PlayerPrefs.GetInt("gun1") == 2)
        {
            Handgun.transform.parent = weaponInvenotry.transform;
            StarterPistol.transform.parent = weaponHolder.transform;
        }

        if (PlayerPrefs.GetInt("gun2") == 2)
        {
            Handgun2.transform.parent = weaponInvenotry.transform;
            StarterPistol.transform.parent = weaponHolder.transform;
        }

        if (PlayerPrefs.GetInt("gun3") == 2)
        {
            SMG.transform.parent = weaponInvenotry.transform;
            StarterPistol.transform.parent = weaponHolder.transform;
        }

        if (PlayerPrefs.GetInt("gun4") == 2)
        {
            MP7.transform.parent = weaponInvenotry.transform;
            StarterPistol.transform.parent = weaponHolder.transform;
        }

        if (PlayerPrefs.GetInt("gun5") == 2)
        {
            Ak47.transform.parent = weaponInvenotry.transform;
            StarterPistol.transform.parent = weaponHolder.transform;
        }

        if (PlayerPrefs.GetInt("gun6") == 2)
        {
            OneShooterGun.transform.parent = weaponInvenotry.transform;
            StarterPistol.transform.parent = weaponHolder.transform;
        }

        if (PlayerPrefs.GetInt("gun7") == 2)
        {
            Shotgun.transform.parent = weaponInvenotry.transform;
            StarterPistol.transform.parent = weaponHolder.transform;
        }

        if (PlayerPrefs.GetInt("gun8") == 2)
        {
            M16.transform.parent = weaponInvenotry.transform;
            StarterPistol.transform.parent = weaponHolder.transform;
        }

        if (PlayerPrefs.GetInt("gun9") == 2)
        {
            M82.transform.parent = weaponInvenotry.transform;
            StarterPistol.transform.parent = weaponHolder.transform;
        }

        if (PlayerPrefs.GetInt("gun10") == 2)
        {
            LMG.transform.parent = weaponInvenotry.transform;
            StarterPistol.transform.parent = weaponHolder.transform;
        }
    }
}
