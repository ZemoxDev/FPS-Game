using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TextScript : MonoBehaviour
{
    public Animator anim;
    public TextMeshProUGUI text;

    public float timer = 7f;
    public bool timerCheck = false;

    public PlayerMovement player;
    public JailBreakoutScript jailBreakout;

    public MeshRenderer loraEyeMesh;
    public Material glowingTalkingMat;
    public Material normalMat;

    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();

        anim = GetComponent<Animator>();
        if(scene.name == "1stLevel")
        {
            anim.SetBool("startText", true);
            timerCheck = true;
            text.SetText("Lora: Where are we? This looks like a prison.");
            loraEyeMesh.material = glowingTalkingMat;
        }
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

        if(player.textSignal == "projector")
        {
            anim.SetBool("startText", true);
            timerCheck = true;
            text.SetText("Lora: Wow I think you need to deactivate this reactor, look at the cables on the wall maybe you find something.");
            loraEyeMesh.material = glowingTalkingMat;
        }

        if (player.textSignal == "nearpit")
        {
            anim.SetBool("startText", true);
            timerCheck = true;
            text.SetText("Lora: Huh we can't jump this, look around here maybe you will find something to get over this pit.");
            loraEyeMesh.material = glowingTalkingMat;
        }

        if (jailBreakout.generatorOff == true)
        {
            anim.SetBool("startText", true);
            timerCheck = true;
            text.SetText("Lora: You have turned off the reactor well done we are almost free. Try running against the cell bars maybe we will be able to break through.");
            loraEyeMesh.material = glowingTalkingMat;
        }

        if(player.textSignal == "pitcollider")
        {
            anim.SetBool("startText", true);
            timerCheck = true;
            text.SetText("Lora: Watch out for the lasers don't get touched by them.");
            loraEyeMesh.material = glowingTalkingMat;
        }

        if (player.textSignal == "staircollider")
        {
            anim.SetBool("startText", true);
            timerCheck = true;
            text.SetText("Lora: There might be more guards around be careful and take them out if you see them. ");
            loraEyeMesh.material = glowingTalkingMat;
        }
    }
}
