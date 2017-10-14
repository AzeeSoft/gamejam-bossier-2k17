using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeckyAttack : MonoBehaviour
{
    [HideInInspector]
    public bool isAttacking = false;

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
            isAttacking = true;
        }
        else
        {
            animator.SetBool("isAttacking", false);
            isAttacking = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("chest"))
        {
            ChestController chestController = collision.gameObject.GetComponent<ChestController>();
            if (!chestController.isOpen)
            {
                chestController.openChest();
            }
        }
    }
}