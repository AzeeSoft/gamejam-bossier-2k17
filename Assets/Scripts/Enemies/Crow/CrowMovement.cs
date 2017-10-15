using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowMovement : MonoBehaviour
{
    public float speed;

    public Transform wallDetectorTransform;

    [HideInInspector]
    public bool isFacingLeft = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        checkAndChangeDirection();
		updateMovement();
	}

    void checkAndChangeDirection()
    {
        Vector2 dir = Vector2.left;
        if (!isFacingLeft)
        {
            dir = Vector2.right;
        }

        RaycastHit2D raycastHit2D = Physics2D.Raycast(wallDetectorTransform.position, dir, 0);
        if (raycastHit2D.rigidbody != null)
        {
            Debug.Log("Raycast Hit: " + raycastHit2D.rigidbody.gameObject.name);
            if (raycastHit2D.rigidbody.gameObject.CompareTag("Ground"))
            {
                isFacingLeft = !isFacingLeft;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }
    }

    void updateMovement()
    {
        Vector2 pos = transform.position;
        if (isFacingLeft)
            pos.x += speed * Time.deltaTime;
        else
            pos.x -= speed * Time.deltaTime;
        transform.position = pos;

//        animator.SetBool("isWalking", true);
    }
}
