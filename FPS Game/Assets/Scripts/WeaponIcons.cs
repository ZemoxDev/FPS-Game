using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIcons : MonoBehaviour
{
    public GameObject M16;
    public GameObject Handgun;
    public GameObject MP7;
    public GameObject M82;
    public GameObject Ak47;
    public GameObject OneShooter;
    public GameObject Shotgun;
    public GameObject SMG;
    public GameObject Handgun2;
    public GameObject CakeLauncher;
    public GameObject StarterPistol;
    public GameObject LMG;

    public Transform Weapons;

    public Transform WeaponIconPosition1;
    public Transform WeaponIconPosition2;
    public Transform WeaponIconPosition3;
    public Transform WeaponIconPosition4;

    void Start()
    {
        if(Weapons.GetChild(0).name == "M16")
        {
            M16.transform.parent = WeaponIconPosition1.transform;
            M16.transform.position = WeaponIconPosition1.position;
            M16.SetActive(true);
        }
        if (Weapons.GetChild(0).name == "Handgun")
        {
            Handgun.transform.parent = WeaponIconPosition1.transform;
            Handgun.transform.position = WeaponIconPosition1.position;
            Handgun.SetActive(true);
        }
        if (Weapons.GetChild(0).name == "MP7")
        {
            MP7.transform.parent = WeaponIconPosition1.transform;
            MP7.transform.position = WeaponIconPosition1.position;
            MP7.SetActive(true);
        }
        if (Weapons.GetChild(0).name == "M82")
        {
            M82.transform.parent = WeaponIconPosition1.transform;
            M82.transform.position = WeaponIconPosition1.position;
            M82.SetActive(true);
        }
        if (Weapons.GetChild(0).name == "Ak 47")
        {
            Ak47.transform.parent = WeaponIconPosition1.transform;
            Ak47.transform.position = WeaponIconPosition1.position;
            Ak47.SetActive(true);
        }
        if (Weapons.GetChild(0).name == "One Shooter Gun")
        {
            OneShooter.transform.parent = WeaponIconPosition1.transform;
            OneShooter.transform.position = WeaponIconPosition1.position;
            OneShooter.SetActive(true);
        }
        if (Weapons.GetChild(0).name == "Shotgun")
        {
            Shotgun.transform.parent = WeaponIconPosition1.transform;
            Shotgun.transform.position = WeaponIconPosition1.position;
            Shotgun.SetActive(true);
        }
        if (Weapons.GetChild(0).name == "SMG")
        {
            SMG.transform.parent = WeaponIconPosition1.transform;
            SMG.transform.position = WeaponIconPosition1.position;
            SMG.SetActive(true);
        }
        if (Weapons.GetChild(0).name == "Handgun 2")
        {
            Handgun2.transform.parent = WeaponIconPosition1.transform;
            Handgun2.transform.position = WeaponIconPosition1.position;
            Handgun2.SetActive(true);
        }
        if (Weapons.GetChild(0).name == "Cake Launcher")
        {
            CakeLauncher.transform.parent = WeaponIconPosition1.transform;
            CakeLauncher.transform.position = WeaponIconPosition1.position;
            CakeLauncher.SetActive(true);
        }
        if (Weapons.GetChild(0).name == "Starter Pistol")
        {
            StarterPistol.transform.parent = WeaponIconPosition1.transform;
            StarterPistol.transform.position = WeaponIconPosition1.position;
            StarterPistol.SetActive(true);
        }
        if (Weapons.GetChild(0).name == "LMG")
        {
            LMG.transform.parent = WeaponIconPosition1.transform;
            LMG.transform.position = WeaponIconPosition1.position;
            LMG.SetActive(true);
        }



        if (Weapons.GetChild(1).name == "M16")
        {
            M16.transform.parent = WeaponIconPosition2.transform;
            M16.transform.position = WeaponIconPosition2.position;
            M16.SetActive(true);
        }
        if (Weapons.GetChild(1).name == "Handgun")
        {
            Handgun.transform.parent = WeaponIconPosition2.transform;
            Handgun.transform.position = WeaponIconPosition2.position;
            Handgun.SetActive(true);
        }
        if (Weapons.GetChild(1).name == "MP7")
        {
            MP7.transform.parent = WeaponIconPosition2.transform;
            MP7.transform.position = WeaponIconPosition2.position;
            MP7.SetActive(true);
        }
        if (Weapons.GetChild(1).name == "M82")
        {
            M82.transform.parent = WeaponIconPosition2.transform;
            M82.transform.position = WeaponIconPosition2.position;
            M82.SetActive(true);
        }
        if (Weapons.GetChild(1).name == "Ak 47")
        {
            Ak47.transform.parent = WeaponIconPosition2.transform;
            Ak47.transform.position = WeaponIconPosition2.position;
            Ak47.SetActive(true);
        }
        if (Weapons.GetChild(1).name == "One Shooter Gun")
        {
            OneShooter.transform.parent = WeaponIconPosition2.transform;
            OneShooter.transform.position = WeaponIconPosition2.position;
            OneShooter.SetActive(true);
        }
        if (Weapons.GetChild(1).name == "Shotgun")
        {
            Shotgun.transform.parent = WeaponIconPosition2.transform;
            Shotgun.transform.position = WeaponIconPosition2.position;
            Shotgun.SetActive(true);
        }
        if (Weapons.GetChild(1).name == "SMG")
        {
            SMG.transform.parent = WeaponIconPosition2.transform;
            SMG.transform.position = WeaponIconPosition2.position;
            SMG.SetActive(true);
        }
        if (Weapons.GetChild(1).name == "Handgun 2")
        {
            Handgun2.transform.parent = WeaponIconPosition2.transform;
            Handgun2.transform.position = WeaponIconPosition2.position;
            Handgun2.SetActive(true);
        }
        if (Weapons.GetChild(1).name == "Cake Launcher")
        {
            CakeLauncher.transform.parent = WeaponIconPosition2.transform;
            CakeLauncher.transform.position = WeaponIconPosition2.position;
            CakeLauncher.SetActive(true);
        }
        if (Weapons.GetChild(1).name == "Starter Pistol")
        {
            StarterPistol.transform.parent = WeaponIconPosition2.transform;
            StarterPistol.transform.position = WeaponIconPosition2.position;
            StarterPistol.SetActive(true);
        }
        if (Weapons.GetChild(1).name == "LMG")
        {
            LMG.transform.parent = WeaponIconPosition2.transform;
            LMG.transform.position = WeaponIconPosition2.position;
            LMG.SetActive(true);
        }



        if (Weapons.GetChild(2).name == "M16")
        {
            M16.transform.parent = WeaponIconPosition3.transform;
            M16.transform.position = WeaponIconPosition3.position;
            M16.SetActive(true);
        }
        if (Weapons.GetChild(2).name == "Handgun")
        {
            Handgun.transform.parent = WeaponIconPosition3.transform;
            Handgun.transform.position = WeaponIconPosition3.position;
            Handgun.SetActive(true);
        }
        if (Weapons.GetChild(2).name == "MP7")
        {
            MP7.transform.parent = WeaponIconPosition3.transform;
            MP7.transform.position = WeaponIconPosition3.position;
            MP7.SetActive(true);
        }
        if (Weapons.GetChild(2).name == "M82")
        {
            M82.transform.parent = WeaponIconPosition3.transform;
            M82.transform.position = WeaponIconPosition3.position;
            M82.SetActive(true);
        }
        if (Weapons.GetChild(2).name == "Ak 47")
        {
            Ak47.transform.parent = WeaponIconPosition3.transform;
            Ak47.transform.position = WeaponIconPosition3.position;
            Ak47.SetActive(true);
        }
        if (Weapons.GetChild(2).name == "One Shooter Gun")
        {
            OneShooter.transform.parent = WeaponIconPosition3.transform;
            OneShooter.transform.position = WeaponIconPosition3.position;
            OneShooter.SetActive(true);
        }
        if (Weapons.GetChild(2).name == "Shotgun")
        {
            Shotgun.transform.parent = WeaponIconPosition3.transform;
            Shotgun.transform.position = WeaponIconPosition3.position;
            Shotgun.SetActive(true);
        }
        if (Weapons.GetChild(2).name == "SMG")
        {
            SMG.transform.parent = WeaponIconPosition3.transform;
            SMG.transform.position = WeaponIconPosition3.position;
            SMG.SetActive(true);
        }
        if (Weapons.GetChild(2).name == "Handgun 2")
        {
            Handgun2.transform.parent = WeaponIconPosition3.transform;
            Handgun2.transform.position = WeaponIconPosition3.position;
            Handgun2.SetActive(true);
        }
        if (Weapons.GetChild(2).name == "Cake Launcher")
        {
            CakeLauncher.transform.parent = WeaponIconPosition3.transform;
            CakeLauncher.transform.position = WeaponIconPosition3.position;
            CakeLauncher.SetActive(true);
        }
        if (Weapons.GetChild(2).name == "Starter Pistol")
        {
            StarterPistol.transform.parent = WeaponIconPosition3.transform;
            StarterPistol.transform.position = WeaponIconPosition3.position;
            StarterPistol.SetActive(true);
        }
        if (Weapons.GetChild(2).name == "LMG")
        {
            LMG.transform.parent = WeaponIconPosition3.transform;
            LMG.transform.position = WeaponIconPosition3.position;
            LMG.SetActive(true);
        }


        if (Weapons.GetChild(3).name == "M16")
        {
            M16.transform.parent = WeaponIconPosition4.transform;
            M16.transform.position = WeaponIconPosition4.position;
            M16.SetActive(true);
        }
        if (Weapons.GetChild(3).name == "Handgun")
        {
            Handgun.transform.parent = WeaponIconPosition4.transform;
            Handgun.transform.position = WeaponIconPosition4.position;
            Handgun.SetActive(true);
        }
        if (Weapons.GetChild(3).name == "MP7")
        {
            MP7.transform.parent = WeaponIconPosition4.transform;
            MP7.transform.position = WeaponIconPosition4.position;
            MP7.SetActive(true);
        }
        if (Weapons.GetChild(3).name == "M82")
        {
            M82.transform.parent = WeaponIconPosition4.transform;
            M82.transform.position = WeaponIconPosition4.position;
            M82.SetActive(true);
        }
        if (Weapons.GetChild(3).name == "Ak 47")
        {
            Ak47.transform.parent = WeaponIconPosition4.transform;
            Ak47.transform.position = WeaponIconPosition4.position;
            Ak47.SetActive(true);
        }
        if (Weapons.GetChild(3).name == "One Shooter Gun")
        {
            OneShooter.transform.parent = WeaponIconPosition4.transform;
            OneShooter.transform.position = WeaponIconPosition4.position;
            OneShooter.SetActive(true);
        }
        if (Weapons.GetChild(3).name == "Shotgun")
        {
            Shotgun.transform.parent = WeaponIconPosition4.transform;
            Shotgun.transform.position = WeaponIconPosition4.position;
            Shotgun.SetActive(true);
        }
        if (Weapons.GetChild(3).name == "SMG")
        {
            SMG.transform.parent = WeaponIconPosition4.transform;
            SMG.transform.position = WeaponIconPosition4.position;
            SMG.SetActive(true);
        }
        if (Weapons.GetChild(3).name == "Handgun 2")
        {
            Handgun2.transform.parent = WeaponIconPosition4.transform;
            Handgun2.transform.position = WeaponIconPosition4.position;
            Handgun2.SetActive(true);
        }
        if (Weapons.GetChild(3).name == "Cake Launcher")
        {
            CakeLauncher.transform.parent = WeaponIconPosition4.transform;
            CakeLauncher.transform.position = WeaponIconPosition4.position;
            CakeLauncher.SetActive(true);
        }
        if (Weapons.GetChild(3).name == "Starter Pistol")
        {
            StarterPistol.transform.parent = WeaponIconPosition4.transform;
            StarterPistol.transform.position = WeaponIconPosition4.position;
            StarterPistol.SetActive(true);
        }
        if (Weapons.GetChild(3).name == "LMG")
        {
            LMG.transform.parent = WeaponIconPosition4.transform;
            LMG.transform.position = WeaponIconPosition4.position;
            LMG.SetActive(true);
        }
    }
}
