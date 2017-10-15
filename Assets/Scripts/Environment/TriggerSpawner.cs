using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : MonoBehaviour {

    public GameObject[] spawnableEnemies;

    bool spawned = false;

    // Use this for initialization
    void Start()
    {
        foreach (GameObject enemy in spawnableEnemies)
        {
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //        Debug.Log("Spawn Triggered");
        if (!spawned && collider.gameObject.CompareTag("pecky"))
        {
            foreach (GameObject enemy in spawnableEnemies)
            {
                enemy.SetActive(true);
            }
            spawned = true;
        }
    }
}
