using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomMovement : MonoBehaviour
{
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
    }
}
