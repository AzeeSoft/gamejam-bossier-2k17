using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeckyAttack : MonoBehaviour
{

    Animator animator;
    GameObject overlappingAttackableObject;

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
            attackOverlappingObject();
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("chest"))
        {
            overlappingAttackableObject = collision.gameObject;
            /*ChestController chestController = collision.gameObject.GetComponent<ChestController>();
            if (!chestController.isOpen && isAttacking)
            {
                chestController.openChest();
            }*/
        }
    }

    void attackOverlappingObject()
    {
        if (overlappingAttackableObject == null)
            return;

        if (overlappingAttackableObject.tag.Equals("chest"))
        {
            ChestController chestController = overlappingAttackableObject.GetComponent<ChestController>();
            chestController.openChest();
        }
    }

}