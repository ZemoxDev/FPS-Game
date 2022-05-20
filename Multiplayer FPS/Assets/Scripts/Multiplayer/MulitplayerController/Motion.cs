using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class Motion : MonoBehaviourPunCallbacks
{
    public float speed;
    public float sprintModifier;
    public float jumpForce;
    public float lengthOfSlide;
    public float crouchMultiplier;
    public float slideModifier;
    public int max_health;
    public Camera normalCam;
    public Transform groundCheck;
    public Transform weaponParent;
    public LayerMask ground;
    public GameObject cameraParent;

    public float crouchAmount;
    public float slideAmount;
    public GameObject standingCollider;
    public GameObject crouchingCollider;

    private Transform ui_healthbar;
    private TextMeshProUGUI ui_ammo;

    private Rigidbody rb;

    private Vector3 targetWeaponBobPosition;
    private Vector3 weaponParentOrigin;
    private Vector3 weaponParentCurrentPos;

    private float movementCounter;
    private float idleCounter;

    private float baseFOV;
    private float sprintFOVModifier = 1.5f;
    private Vector3 origin;

    private int current_health;

    private Manager manager;
    private Weapon weapon;

    private bool sliding;
    private bool crouched;
    private float slide_time;
    private Vector3 slide_dir;

    void Awake()
    {
        current_health = max_health;

        cameraParent.SetActive(photonView.IsMine);

        if (!photonView.IsMine)
        {
            gameObject.layer = 10;
            crouchingCollider.layer = 10;
            standingCollider.layer = 10;
        }

        baseFOV = normalCam.fieldOfView;
        origin = normalCam.transform.localPosition;

        rb = GetComponent<Rigidbody>();
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        weapon = GetComponent<Weapon>();
        weaponParentOrigin = weaponParent.localPosition;
        weaponParentCurrentPos = weaponParentOrigin;

        if (photonView.IsMine)
        {
            ui_healthbar = GameObject.Find("HUD/Health/Bar").transform;
            ui_ammo = GameObject.Find("HUD/Ammo/Text").GetComponent<TextMeshProUGUI>();
            RefreshHealthBar();
        }
    }

    void Update()
    {
        if (!photonView.IsMine)
            return;

        //Axis
        float hMove = Input.GetAxisRaw("Horizontal");
        float vMove = Input.GetAxisRaw("Vertical");

        //Controls
        bool sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool jump = Input.GetKeyDown(KeyCode.Space);
        bool crouch = Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl);

        //States
        bool isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, 0.1f, ground);
        bool isJumping = jump && isGrounded;
        bool isSprinting = sprint && vMove > 0 && !isJumping && isGrounded;
        bool isCrouching = crouch && !isSprinting && !isJumping && isGrounded;


        if(isCrouching)
        {
            photonView.RPC("SetCrouch", RpcTarget.All, !crouched);
        }

        //Jumping
        if (isJumping)
        {
            if(crouched)
            {
                photonView.RPC("SetCrouch", RpcTarget.All, false);
            }
            rb.AddForce(Vector3.up * jumpForce);
        }

        //Head Bob
        if (hMove == 0 && vMove == 0)
        {
            HeadBob(idleCounter, 0.01f, 0.01f);
            idleCounter += Time.deltaTime;
            weaponParent.localPosition = Vector3.Lerp(weaponParent.localPosition, targetWeaponBobPosition, Time.deltaTime * 2f);
        }
        else if(!isSprinting && !crouched)
        {
            HeadBob(movementCounter, 0.025f, 0.025f);
            movementCounter += Time.deltaTime * 3f;
            weaponParent.localPosition = Vector3.Lerp(weaponParent.localPosition, targetWeaponBobPosition, Time.deltaTime * 8f);
        }
        else if(crouched)
        {
            HeadBob(movementCounter, 0.02f, 0.02f);
            movementCounter += Time.deltaTime * 1.75f;
            weaponParent.localPosition = Vector3.Lerp(weaponParent.localPosition, targetWeaponBobPosition, Time.deltaTime * 6f);
        }
        else
        {
            HeadBob(movementCounter, 0.1f, 0.045f);
            movementCounter += Time.deltaTime * 5f;
            weaponParent.localPosition = Vector3.Lerp(weaponParent.localPosition, targetWeaponBobPosition, Time.deltaTime * 9f);
        }

        if (Input.GetKeyDown(KeyCode.U)) TakeDamage(10);

        //UI Refresh
        RefreshHealthBar();
        weapon.RefreshAmmo(ui_ammo);
    }

    void FixedUpdate()
    {
        if (!photonView.IsMine)
            return;

        //Axis
        float hMove = Input.GetAxisRaw("Horizontal");
        float vMove = Input.GetAxisRaw("Vertical");

        //Controls
        bool sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool jump = Input.GetKeyDown(KeyCode.Space);
        bool slide = Input.GetKey(KeyCode.C);

        //States
        bool isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, 0.1f, ground);
        bool isJumping = jump && isGrounded;
        bool isSprinting = sprint && vMove > 0 && !isJumping && isGrounded;
        bool isSliding = isSprinting && slide && !sliding;

        //Movement
        Vector3 direction = Vector3.zero;
        float adjustSpeed = speed;

        if (!sliding)
        {
            direction = new Vector3(hMove, 0, vMove);
            direction.Normalize();
            direction = transform.TransformDirection(direction);

            if (isSprinting)
            {
                if(crouched)
                {
                    photonView.RPC("SetCrouch", RpcTarget.All, false);
                }
                adjustSpeed *= sprintModifier;
            }
            else if (crouched)
            {
                adjustSpeed *= crouchMultiplier;
            }
        }
        else
        {
            direction = slide_dir;
            adjustSpeed *= slideModifier;
            slide_time -= Time.deltaTime;
            if(slide_time <= 0)
            {
                sliding = false;
                weaponParentCurrentPos -= Vector3.down * (slideAmount - crouchAmount);
            }
        }

        Vector3 targetVelocity = direction * adjustSpeed * Time.deltaTime;
        targetVelocity.y = rb.velocity.y;
        rb.velocity = targetVelocity;

        //Sliding
        if (isSliding)
        {
            sliding = true;
            slide_dir = direction;
            slide_time = lengthOfSlide;
            weaponParentCurrentPos += Vector3.down * (slideAmount - crouchAmount);
            if(!crouched)
            {
                photonView.RPC("SetCrouch", RpcTarget.All, true);
            }
        }

        //FOV
        if(sliding)
        {
            normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV * sprintFOVModifier * 1.15f, Time.deltaTime *8f);
            normalCam.transform.localPosition = Vector3.Lerp(normalCam.transform.localPosition, origin + Vector3.down * slideAmount, Time.deltaTime * 6f);
        }
        else
        {
            if (isSprinting)
            {
                normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV * sprintFOVModifier, Time.deltaTime * 6f);
            }
            else
            {
                normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV, Time.deltaTime * 6f);
            }

            if(crouched)
            {
                normalCam.transform.localPosition = Vector3.Lerp(normalCam.transform.localPosition, origin + Vector3.down * crouchAmount, Time.deltaTime * 6f);
            }
            else
            {
                normalCam.transform.localPosition = Vector3.Lerp(normalCam.transform.localPosition, origin, Time.deltaTime * 6f);
            }
        }
    }

    void HeadBob(float z, float x_intensity, float y_intensity)
    {
        float aim_adjust = 1f;
        if (weapon.aiming) aim_adjust = 0.1f;
        targetWeaponBobPosition = weaponParentCurrentPos + new Vector3(Mathf.Cos(z) * x_intensity * aim_adjust, Mathf.Sin(z * 2) * y_intensity * aim_adjust, 0);
    }

    void RefreshHealthBar()
    {
        float health_ratio = (float)current_health / (float)max_health;
        ui_healthbar.localScale = Vector3.Lerp(ui_healthbar.localScale, new Vector3(health_ratio, 1, 1), Time.deltaTime * 8f);
    }

    [PunRPC]
    void SetCrouch(bool state)
    {
        if (crouched == state) return;

        crouched = state;

        if(crouched)
        {
            standingCollider.SetActive(false);
            crouchingCollider.SetActive(true);
            weaponParentCurrentPos += Vector3.down * crouchAmount;
        }
        else
        {
            standingCollider.SetActive(true);
            crouchingCollider.SetActive(false);
            weaponParentCurrentPos -= Vector3.down * crouchAmount;
        }
    }

    [PunRPC]
    public void TakeDamage (int damage)
    {
        if(photonView.IsMine)
        {
            current_health -= damage;
            RefreshHealthBar();

            if(current_health <= 0)
            {
                manager.Spawn();
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }
}
