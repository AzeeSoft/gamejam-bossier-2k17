using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pecky"))
        {
            PeckyController peckyController = collision.gameObject.GetComponent<PeckyController>();
            peckyController.die();
        }
    }
}
