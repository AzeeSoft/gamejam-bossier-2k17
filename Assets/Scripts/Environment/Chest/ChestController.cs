using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public Sprite openChestSprite;
    public GameObject lifePrefab;

    [HideInInspector]
    public bool isOpen = false;

    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void openChest()
    {
        if (!isOpen)
        {
            revealItem();
            spriteRenderer.sprite = openChestSprite;
            isOpen = true;
            Debug.Log("Opening Chest...");
        }
    }

    private void revealItem()
    {
        GameObject item;

        //For now, juz +1 Life
        MainSceneManager mainSceneManager = MainSceneManager.getMainSceneManager();
        mainSceneManager.addLife();
        item = GameObject.Instantiate(lifePrefab, transform.position, transform.rotation);


        StartCoroutine(StaticTools.NotifyCollectible(item, 10));
    }
}