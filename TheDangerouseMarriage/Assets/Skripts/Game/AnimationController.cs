using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        if (GameObject.Find("Player").GetComponent<PlayerController>().isMale)
        {
            anim.SetBool("isMale", true);
        }
        
	}

    // Update is called once per frame
	void Update () {
        if (GameObject.Find("Player").GetComponent<PlayerController>().isMale)
        {
            anim.SetBool("isMale", true);
        }
        else
        {
            anim.SetBool("isMale", false);
        }

        if (!GameObject.Find("Background").GetComponent<GameManagement>().waitForNewDay)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetInteger("State", 1);
            }
            else
            {
                anim.SetInteger("State", 0);
            }

            /*
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                anim.SetInteger("State", 0);
            }
            */
        }
    }
}
