using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    public float damage = 15f;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            anim.SetBool("Attacking", true);

            anim.enabled = true;
            StartCoroutine("SetAttackingToFalse");
        }
    }

    private IEnumerator SetAttackingToFalse()
    {
        yield return new WaitForSeconds(.95f);

        anim.SetBool("Attacking", false);

        yield return new WaitForSeconds(.25f);
        anim.enabled = false;

        yield return null;
    }
}
