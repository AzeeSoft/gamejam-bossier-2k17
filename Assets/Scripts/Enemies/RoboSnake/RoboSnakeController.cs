using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboSnakeController : MonoBehaviour
{
    public int points = 10;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bounder"))
        {
            Destroy(gameObject);
        }
    }

    public void die()
    {
        Destroy(gameObject);
    }
}