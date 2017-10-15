using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowMovement : MonoBehaviour
{
    public float speed;

	// Use this for initialization
	void Start () {
		
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

//        animator.SetBool("isWalking", true);
    }
}
