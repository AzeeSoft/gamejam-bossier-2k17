﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("pecky"))
        {
            PeckyController peckyController = collider.gameObject.GetComponent<PeckyController>();
            peckyController.die();
            Destroy(gameObject);
        }
        if (collider.gameObject.CompareTag("bounder"))
        {
            Destroy(gameObject);
        }
    }
}
