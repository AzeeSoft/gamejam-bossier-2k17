using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeckyAttack : MonoBehaviour
{
    public GameObject groundCheckerLeft;
    public GameObject groundCheckerRight;

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
//        checkCrush();
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

    /*void checkCrush()
    {
        RaycastHit2D raycastHit2DLeft = Physics2D.Raycast(groundCheckerLeft.transform.position, Vector2.down, 0);
        RaycastHit2D raycastHit2DRight = Physics2D.Raycast(groundCheckerRight.transform.position, Vector2.down, 0);

        GameObject crushableGameObjectLeft = null;
        GameObject crushableGameObjectRight = null;
        if (raycastHit2DLeft.rigidbody != null)
        {
            crushableGameObjectLeft = raycastHit2DLeft.rigidbody.gameObject; 
        }
        if (raycastHit2DRight.rigidbody != null)
        {
            crushableGameObjectRight = raycastHit2DLeft.rigidbody.gameObject;
            if (crushableGameObjectRight == crushableGameObjectRight)
            {
                crushableGameObjectRight = null;
            }
        }

        crushObject(crushableGameObjectLeft);
        crushObject(crushableGameObjectRight);
    }*/

    /*void crushObject(GameObject crushableGameObject)
    {
        if (crushableGameObject != null)
        {
            if (crushableGameObject.CompareTag("RoboSnake"))
            {
                RoboSnakeController roboSnakeController = crushableGameObject.GetComponent<RoboSnakeController>();
                roboSnakeController.die();
            }
        }
    }*/

    void OnTriggerEnter2D(Collider2D collision)
    {
        MainSceneManager mainSceneManager = MainSceneManager.getMainSceneManager();
        AudioSource audioSource = GetComponent<AudioSource>();
        if (collision.gameObject.tag.Equals("chest"))
        {
            overlappingAttackableObject = collision.gameObject;
        }
        else if (collision.gameObject.CompareTag("RoboSnakeCrushDetector"))
        {
            RoboSnakeController roboSnakeController =
                collision.gameObject.transform.GetComponentInParent<RoboSnakeController>();
            roboSnakeController.die();
            mainSceneManager.addCurrentScore(roboSnakeController.points);
            audioSource.Play();
        }
        else if (collision.gameObject.CompareTag("AligatorCrushDetector"))
        {
            AligatorController aligatorController =
                collision.gameObject.transform.GetComponentInParent<AligatorController>();
            aligatorController.die();
            mainSceneManager.addCurrentScore(aligatorController.points);
            audioSource.Play();
        }
        else if (collision.gameObject.CompareTag("CrowCrushDetector"))
        {
            CrowController crowController =
                collision.gameObject.transform.GetComponentInParent<CrowController>();
            crowController.die();
            mainSceneManager.addCurrentScore(crowController.points);
            audioSource.Play();
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