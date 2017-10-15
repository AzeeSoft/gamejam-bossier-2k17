using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounderController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void destroyObject(GameObject outOfBoundGameObject)
    {
        if (outOfBoundGameObject != null)
        {
//            Debug.Log("Destroying "+gameObject.tag);
            if (!outOfBoundGameObject.CompareTag("pecky"))
            {
                Destroy(outOfBoundGameObject.gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        destroyObject(collision.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        destroyObject(collider.gameObject);
    }
}
