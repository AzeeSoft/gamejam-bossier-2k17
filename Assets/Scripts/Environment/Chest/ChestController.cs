using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public Sprite openChestSprite;

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
            spriteRenderer.sprite = openChestSprite;
            isOpen = true;
            Debug.Log("Opening Chest...");
        }
    }
}