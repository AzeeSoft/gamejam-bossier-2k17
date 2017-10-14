using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeckyAttack : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        checkAttack();
    }

    void checkAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Pecky Strikes!");    //TODO: Implement actual attack functionality
        }
    }
}