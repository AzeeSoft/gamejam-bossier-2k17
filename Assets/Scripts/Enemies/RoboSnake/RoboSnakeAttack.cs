using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboSnakeAttack : MonoBehaviour
{
    public GameObject venom;
    public Transform spitterTransform;
    public float spitInterval;

	// Use this for initialization
	void Start () {
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
        GameObject.Instantiate(venom, spitterTransform.position, spitterTransform.rotation);
    }
}
