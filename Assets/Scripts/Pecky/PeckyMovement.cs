using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeckyMovement : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;
//    public float camOffset;
    public bool facingRight;

    [HideInInspector] public bool isGrounded = true;

    public GameObject groundCheckerLeft;
    public GameObject groundCheckerRight;

    Rigidbody2D rb2d;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
//        alignWithCamera();
    }

    // Update is called once per frame
    void Update()
    {
        checkJump();
        updateMovement();
    }

    void checkJump()
    {
        RaycastHit2D raycastHit2DLeft = Physics2D.Raycast(groundCheckerLeft.transform.position, Vector2.down, 0);
        RaycastHit2D raycastHit2DRight = Physics2D.Raycast(groundCheckerRight.transform.position, Vector2.down, 0);

        if (raycastHit2DLeft.rigidbody != null || raycastHit2DRight.rigidbody != null)
        {
            animator.SetBool("isJumping", false);
            if (Input.GetButtonDown("Jump"))
            {
                rb2d.AddForce(Vector2.up*jumpForce);
            }
            isGrounded = true;
        }
        else
        {
//            Debug.Log("Jumping...");
            animator.SetBool("isJumping", true);
            isGrounded = false;
        }
    }

    void updateMovement()
    {
        float x = Input.GetAxis("Horizontal");

        if (x == 0)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }

        if ((x < 0 && facingRight) || (x > 0 && !facingRight))
        {
            facingRight = !facingRight;
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        Vector3 pos = transform.position;
        pos.x += x*playerSpeed*Time.deltaTime;
        transform.position = pos;
    }

    /*public void alignWithCamera()
    {
        Vector2 camBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
//        Debug.Log("Camera Rect: "+ camBottomLeft);
        Vector2 pos = transform.position;
        pos.x = camBottomLeft.x + camOffset;
        transform.localPosition = pos;
    }*/
}