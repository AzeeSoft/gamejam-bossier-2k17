using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AligatorMovement : MonoBehaviour
{
    public float speed;

    bool isFacingLeft;

    Animator animator;

	// Use this for initialization
	void Start ()
	{
	    animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		updateMovement();
	}

    void updateMovement()
    {
        Vector2 pos = transform.position;
        pos.x += speed*Time.deltaTime;
        transform.position = pos;

        animator.SetBool("isWalking", true);
    }
}
