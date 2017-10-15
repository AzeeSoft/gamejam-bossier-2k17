using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AligatorAttack : MonoBehaviour
{
    Animator animator;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pecky"))
        {
            animator.SetTrigger("isAttacking");
            PeckyController peckyController = collision.gameObject.GetComponent<PeckyController>();
            peckyController.die();
        }
    }
}
