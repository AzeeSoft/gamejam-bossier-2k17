using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowController : MonoBehaviour
{
    public Transform eggSpawner;
    public GameObject eggPrefab;
    public float eggDropInterval;
    public int points = 15;

    // Use this for initialization
    void Start () {
		startDroppingEggs();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void startDroppingEggs()
    {
        StartCoroutine(dropEggsCoroutine());
    }

    IEnumerator dropEggsCoroutine()
    {
        while (gameObject != null)
        {
            dropEggs();
            yield return new WaitForSeconds(eggDropInterval);
        }
    }

    void dropEggs()
    {
        GameObject.Instantiate(eggPrefab, eggSpawner.position, eggSpawner.rotation);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
//        Debug.Log("Destroying out of bounds...");
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
