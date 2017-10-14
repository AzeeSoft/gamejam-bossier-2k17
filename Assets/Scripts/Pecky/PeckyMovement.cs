using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeckyMovement : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;

    public bool facingRight = true;

    Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkForJump();
        updateMovement();
    }

    void checkForJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb2d.AddForce(Vector2.up * jumpForce);
        }
    }

    void updateMovement()
    {
        float x = Input.GetAxis("Horizontal");

        if ((x < 0 && facingRight) || (x > 0 && !facingRight))
        {
            facingRight = !facingRight;
            Vector3 scale = StaticTools.CloneVector3(transform.localScale);
            scale.x *= -1;
            transform.localScale = scale;
        }

        Vector3 pos = StaticTools.CloneVector3(transform.localPosition);
        pos.x += x * playerSpeed;
        transform.localPosition = pos;
    }
}