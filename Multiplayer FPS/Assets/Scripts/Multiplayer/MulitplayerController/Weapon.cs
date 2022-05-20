using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class Weapon : MonoBehaviourPunCallbacks
{
    public Gun[] loadout;
    public Transform weaponParent;

    private float currentCooldown;
    private int currentIndex;
    private GameObject currentWeapon;
    public GameObject bulletholePrefab;
    public GameObject impactEffect;
    public LayerMask canBeShot;
    public bool aiming = false;

    private ParticleSystem muzzleFlash;

    private Image hitmarker;
    private float hitmarkerWait;

    private bool isReloading = false;

    void Start()
    {
        foreach (Gun a in loadout) a.Initialize();
        hitmarker = GameObject.Find("HUD/Hitmarker/Image").GetComponent<Image>();
        hitmarker.color = new Color(1, 1, 1, 0);
        Equip(0);
    }

    void Update()
    {
        if (photonView.IsMine && Input.GetKeyDown(KeyCode.Alpha1))
        {
            photonView.RPC("Equip", RpcTarget.All, 0);
        }

        if (photonView.IsMine && Input.GetKeyDown(KeyCode.Alpha2))
        {
            photonView.RPC("Equip", RpcTarget.All, 1);
        }

        if (photonView.IsMine && Input.GetKeyDown(KeyCode.Alpha3))
        {
            photonView.RPC("Equip", RpcTarget.All, 2);
        }

        if (currentWeapon != null)
        {
            if(photonView.IsMine)
            {
                Aim(Input.GetMouseButton(1));

                if(loadout[currentIndex].burst != 1)
                {
                    if (Input.GetMouseButtonDown(0) && currentCooldown <= 0 && isReloading == false)
                    {
                        if (loadout[currentIndex].FireBullet())
                        {
                            photonView.RPC("Shoot", RpcTarget.All);
                        }
                        else
                        {
                            StartCoroutine(Reload(loadout[currentIndex].reload));
                        }
                    }
                }
                else
                {
                    if (Input.GetMouseButton(0) && currentCooldown <= 0 && isReloading == false)
                    {
                        if (loadout[currentIndex].FireBullet())
                        {
                            photonView.RPC("Shoot", RpcTarget.All);
                        }
                        else
                        {
                            StartCoroutine(Reload(loadout[currentIndex].reload));
                        }
                    }
                }

                if(Input.GetKeyDown(KeyCode.R))
                {
                    StartCoroutine(Reload(loadout[currentIndex].reload));
                    isReloading = true;
                }

                //Cooldown
                if (currentCooldown > 0) currentCooldown -= Time.deltaTime;
            }

            //Weapon Elasticity
            currentWeapon.transform.localPosition = Vector3.Lerp(currentWeapon.transform.localPosition, Vector3.zero, Time.deltaTime * 4f);
        }

        if(photonView.IsMine)
        {
            if(hitmarkerWait > 0)
            {
                hitmarkerWait -= Time.deltaTime;
            }
            else if(hitmarker.color.a > 0)
            {
                hitmarker.color = Color.Lerp(hitmarker.color, new Color(1, 1, 1, 0), Time.deltaTime * 1.5f);
            }
        }
    }

    IEnumerator Reload(float wait)
    {
        isReloading = true;
        currentWeapon.SetActive(false);
        yield return new WaitForSeconds(wait);
        loadout[currentIndex].Reload();
        currentWeapon.SetActive(true);
        isReloading = false;
    }

    public void RefreshAmmo(TextMeshProUGUI text)
    {
        int clip = loadout[currentIndex].GetClip();
        int stache = loadout[currentIndex].GetStash();

        text.text = clip.ToString("D2") + " / " + stache.ToString("D2");
    }

    [PunRPC]
    void Equip(int ind)
    {
        if (currentWeapon != null)
        {
            StopCoroutine("Reload");
            Destroy(currentWeapon);
        }

        currentIndex = ind;

        GameObject newWeapon = Instantiate(loadout[ind].prefab, weaponParent.position, weaponParent.rotation, weaponParent) as GameObject;
        newWeapon.transform.localPosition = Vector3.zero;
        newWeapon.transform.localEulerAngles = Vector3.zero;
        newWeapon.GetComponent<Sway>().isMine = photonView.IsMine;

        currentWeapon = newWeapon;
    }

    void Aim(bool isAiming)
    {
        aiming = isAiming;
        Transform anchor = currentWeapon.transform.Find("Anchor");
        Transform state_aim = currentWeapon.transform.Find("States/Aim");
        Transform state_hip = currentWeapon.transform.Find("States/Hip");

        if (isAiming)
        {
            anchor.position = Vector3.Lerp(anchor.position, state_aim.position, Time.deltaTime * loadout[currentIndex].aimSpeed);
        }
         else
        {
            anchor.position = Vector3.Lerp(anchor.position, state_hip.position, Time.deltaTime * loadout[currentIndex].aimSpeed);
        }
    }

    [PunRPC]
    void Shoot()
    {
        Transform spawn = transform.Find("CameraParent/Camera");

        //Cooldown
        currentCooldown = loadout[currentIndex].firerate;

        for(int i = 0; i < Mathf.Max(1, loadout[currentIndex].pellets); i++)
        {
            //Bloom
            Vector3 bloom = spawn.position + spawn.forward * 1000f;
            bloom += Random.Range(-loadout[currentIndex].bloom, loadout[currentIndex].bloom) * spawn.up;
            bloom += Random.Range(-loadout[currentIndex].bloom, loadout[currentIndex].bloom) * spawn.right;
            bloom -= spawn.position;
            bloom.Normalize();

            //Raycast
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(spawn.position, bloom, out hit, 1000f, canBeShot) && isReloading == false)
            {
                GameObject newHole = Instantiate(bulletholePrefab, hit.point + hit.normal * 0.001f, Quaternion.identity) as GameObject;
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                newHole.transform.LookAt(hit.point + hit.normal);
                Destroy(newHole, 5f);

                if (photonView.IsMine)
                {
                    if (hit.collider.gameObject.layer == 10)
                    {
                        hit.collider.transform.root.gameObject.GetPhotonView().RPC("TakeDamage", RpcTarget.All, loadout[currentIndex].damage);

                        hitmarker.color = Color.white;
                        hitmarkerWait = 0.5f;
                    }
                }
            }
        }

        //Gun FX
        currentWeapon.transform.position -= currentWeapon.transform.forward * loadout[currentIndex].kickback;
    }

    [PunRPC]
    private void Damage (int damage)
    {
        GetComponent<Motion>().TakeDamage(damage);
    }
}
