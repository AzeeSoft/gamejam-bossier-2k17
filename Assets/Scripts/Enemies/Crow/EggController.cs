using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("pecky"))
        {
            PeckyController peckyController = collider.gameObject.GetComponent<PeckyController>();
            peckyController.die();
            Destroy(gameObject);
        }
        else if (collider.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}