using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeckyAttack : MonoBehaviour
{

    Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        checkAttack();
    }

    void checkAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Pecky Strikes!"); //TODO: Implement actual attack functionality
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }
}