using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeckyController : MonoBehaviour
{
    public float invincibleAlpha;
    public int invinciblePeriod;
    public Transform respawnLocation;

    SpriteRenderer spriteRenderer;

    bool canDie = true;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void die()
    {
        if (!canDie)
            return;

        MainSceneManager mainSceneManager = MainSceneManager.getMainSceneManager();
        if (mainSceneManager.loseLife())
        {
            Vector3 pos = transform.position;
            pos.y = 5;
            transform.position = pos;

            Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
            Vector3 vel = rb2d.velocity;
            vel.x = 0;
            vel.y = 0;
            vel.z = 0;
            rb2d.velocity = vel;

            StartCoroutine(makeInvincibleTemp());
        }
//        Destroy(gameObject);
    }

    IEnumerator makeInvincibleTemp()
    {
        Color color = spriteRenderer.color;
        color.a = invincibleAlpha;
        spriteRenderer.color = color;

        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;

        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.isKinematic = true;

        PeckyMovement peckyMovement = GetComponent<PeckyMovement>();
        float origSpeed = peckyMovement.playerSpeed;
        peckyMovement.playerSpeed /= 2;

        canDie = false;

        yield return new WaitForSeconds(invinciblePeriod);

        color.a = 255;
        spriteRenderer.color = color;
        boxCollider2D.enabled = true;
        rb2d.isKinematic = false;

        peckyMovement.playerSpeed = origSpeed;

        canDie = true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("VictoryEnd"))
        {
            MainSceneManager mainSceneManager = MainSceneManager.getMainSceneManager();
            mainSceneManager.victory();
        }
    }
}