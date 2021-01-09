using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TextScript2 : MonoBehaviour
{
    public Animator anim;
    public TextMeshProUGUI text;

    public float timer = 7f;
    public bool timerCheck = false;

    public PlayerMovement player;

    public MeshRenderer loraEyeMesh;
    public Material glowingTalkingMat;
    public Material normalMat;

    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();

        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (timerCheck)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            timerCheck = false;
            timer = 7f;
            anim.SetBool("startText", false);
            loraEyeMesh.material = normalMat;
        }

        if(player.textSignal == "elevatortrigger")
        {
            anim.SetBool("startText", true);
            timerCheck = true;
            text.SetText("Lora: Hurry up we really need to leave they are after us! ");
            loraEyeMesh.material = glowingTalkingMat;
        }
    }
}