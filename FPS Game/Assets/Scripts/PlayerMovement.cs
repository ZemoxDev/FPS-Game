using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private const float NORMAL_FOV = 60f;
    private const float HOOKSHOT_FOV = 100f;

    [SerializeField] private Transform hookshotTransform;
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -20f;
    public float jumpHeight = 3f;

    public float health = 100f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float timer = 2f;
    public bool timerCheck = false;

    public float range = 200f;

    Vector3 velocity;
    bool isGrounded;

    public Camera playerCamera;

    private CameraFov cameraFov;

    public GameObject Projectile;

    private float hookshotSize;
    private Vector3 hookshotPosition;
    private State state;

    public ParticleSystem speedLinesParticleSystem1;
    public ParticleSystem speedLinesParticleSystem2;
    public ParticleSystem speedLinesParticleSystem3;

    public float currentSpeed = 0f;
    private enum State
    {
        Normal,
        HookshotThrown,
        HookshotFlyingPlayer
    }

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active scene is '" + scene.name + "'.");

        speedLinesParticleSystem1.Stop();
        speedLinesParticleSystem2.Stop();
        speedLinesParticleSystem3.Stop();
    }   

    private void Awake()
    {
        state = State.Normal;
        cameraFov = playerCamera.GetComponent<CameraFov>();
        hookshotTransform.gameObject.SetActive(false);
    }

    void Update()
    {
        switch(state)
        {
            default:
            case State.Normal:
                HandleHookshotStart();
                break;
            case State.HookshotThrown:
                HandleHookshotThrow();
                break;
            case State.HookshotFlyingPlayer:
                HandleHookshotMovement();
                break;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if(Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            speed = 20f;
        }

        if (Input.GetKey(KeyCode.LeftShift) == false && isGrounded)
        {
            speed = 12f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(timerCheck)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0)
        {
            timerCheck = false;
            gravity = -20f;
            timer = 2f;
        }
    }

    Vector3 lastPosition = Vector3.zero;
    private void FixedUpdate()
    {
        currentSpeed = (transform.position - lastPosition).magnitude / Time.fixedDeltaTime;
        lastPosition = transform.position;

        if(currentSpeed <= 15f)
        {
            speedLinesParticleSystem1.Play();
        }

        if (currentSpeed <= 20f)
        {
            speedLinesParticleSystem2.Play();
        }

        if (currentSpeed <= 25f)
        {
            speedLinesParticleSystem3.Play();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch(hit.gameObject.tag)
        {
            case "SpeedPad":
                speed = 40f;
                jumpHeight = 6f;
                break;

            case "Ground":
                jumpHeight = 3f;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "GravityPad":
                gravity = 2f;
                timerCheck = true;
                break;
        }

        if (other.gameObject.tag == "ChangeScene")
        {
            SceneManager.LoadScene("NextLevel");
        }

        if(other.gameObject.tag == "ChangeScene2")
        {
            SceneManager.LoadScene("3rdLevel");
        }

        if (other.gameObject.tag == "ChangeScene3")
        {
            SceneManager.LoadScene("4thLevel");
        }

        if(other.gameObject.tag == "Bullet")
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        health -= 20f;
        if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        player.transform.position = respawnPoint.transform.position;
        Physics.SyncTransforms();

        health = 100f;
    }

    private void ResetGravityEffect()
    {
        gravity = -20f;
    }

    private void HandleHookshotStart()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (TestInputDownHookshot() && scene.name == "3rdLevel" | scene.name == "5thLevel" | scene.name == "TestLevel")
        {
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit raycastHit, range))
            {
                hookshotPosition = raycastHit.point;
                hookshotSize = 0f;
                hookshotTransform.gameObject.SetActive(true);
                hookshotTransform.localScale = Vector3.zero;
                state = State.HookshotThrown;
            }
        }
    }

    private void HandleHookshotThrow()
    {
        hookshotTransform.LookAt(hookshotPosition);

        float hookshotThrowSpeed = 60f;
        hookshotSize += hookshotThrowSpeed * Time.deltaTime;
        hookshotTransform.localScale = new Vector3(1, 1, hookshotSize);

        if(hookshotSize >= Vector3.Distance(transform.position, hookshotPosition))
        {
            state = State.HookshotFlyingPlayer;
            cameraFov.SetCameraFov(HOOKSHOT_FOV);
        }
    }

    private void HandleHookshotMovement()
    {
        hookshotTransform.LookAt(hookshotPosition);
        Vector3 hookshotDir = (hookshotPosition - transform.position).normalized;

        float hookshotSpeedMin = 10f;
        float hookshotSpeedMax = 30f;
        float hookshotSpeed = Mathf.Clamp(Vector3.Distance(transform.position, hookshotPosition), hookshotSpeedMin, hookshotSpeedMax);
        float hookshotSpeedMultiplier = 4f;

        controller.Move(hookshotDir * hookshotSpeed * hookshotSpeedMultiplier * Time.deltaTime);

        float reachedHookshotPositionDistance = 3f;
        if(Vector3.Distance(transform.position, hookshotPosition) < reachedHookshotPositionDistance)
        {
            state = State.Normal;
            ResetGravityEffect();
            hookshotTransform.gameObject.SetActive(false);
            cameraFov.SetCameraFov(NORMAL_FOV);
        }

        if (TestInputDownHookshot())
        {
            state = State.Normal;
            ResetGravityEffect();
            hookshotTransform.gameObject.SetActive(false);
            cameraFov.SetCameraFov(NORMAL_FOV);
        }

    }

    private bool TestInputDownHookshot()
    {
        return Input.GetKeyDown(KeyCode.C);
    }
}
