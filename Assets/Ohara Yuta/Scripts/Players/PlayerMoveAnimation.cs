using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveAnimation : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("move", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetInteger("move", 1);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            animator.SetInteger("move", -1);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
        else
        {
            animator.SetInteger("move", 0);
        }
    }
}
