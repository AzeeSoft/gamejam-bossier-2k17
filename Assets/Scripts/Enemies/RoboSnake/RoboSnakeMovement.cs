using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboSnakeMovement : MonoBehaviour
{

    public float speed;

    Animator animator;

	// Use this for initialization
	void Start ()
	{
	    animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		updateMovement();
	}

    void updateMovement()
    {
        Vector2 pos = transform.position;
        pos.x += speed;
        transform.position = pos;

        animator.SetBool("isWalking", true);
    }
}
