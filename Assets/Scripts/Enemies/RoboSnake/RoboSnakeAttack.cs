using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboSnakeAttack : MonoBehaviour
{
    public GameObject venom;
    public Transform spitterTransform;
    public float spitInterval;

    Animator animator;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();

        startFiring();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void startFiring()
    {
        StartCoroutine(fireCoroutine());
    }

    IEnumerator fireCoroutine()
    {
        while (gameObject!=null)
        {
            fire();
            yield return new WaitForSeconds(spitInterval);
        }
    }

    void fire()
    {
        animator.SetTrigger("isAttacking");
        GameObject.Instantiate(venom, spitterTransform.position, spitterTransform.rotation);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pecky"))
        {
            animator.SetTrigger("isAttacking");
            PeckyController peckyController = collision.gameObject.GetComponent<PeckyController>();
            peckyController.die();
            /*SpriteRenderer peckySpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            float peckyBottom = peckySpriteRenderer.bounds.center.y + collision.gameObject.transform.position.y + (peckySpriteRenderer.bounds.size.y/2);

            SpriteRenderer mySpriteRenderer = GetComponent<SpriteRenderer>();
            float myTop= mySpriteRenderer.bounds.center.y + transform.position.y - (mySpriteRenderer.bounds.size.y / 2);

            Debug.Log("Attacking...");
            Debug.Log(peckySpriteRenderer.bounds.center);
            Debug.Log(peckySpriteRenderer.bounds.size);
            Debug.Log(peckyBottom);
            Debug.Log(mySpriteRenderer.bounds.center);
            Debug.Log(peckySpriteRenderer.bounds.size);
            Debug.Log(myTop);

            if (myTop > peckyBottom)
            {
                animator.SetTrigger("isAttacking");
                PeckyController peckyController = collision.gameObject.GetComponent<PeckyController>();
                peckyController.die();
            }
            else
            {
                RoboSnakeController roboSnakeController = GetComponent<RoboSnakeController>();
                roboSnakeController.die();
            }*/
        }
    }
}
