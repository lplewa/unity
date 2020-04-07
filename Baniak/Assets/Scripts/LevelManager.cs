using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject ui;
    public Text characterName;
    public Text lines;
    public Animator dialogueAnimator;
   // private List<InventoryItem> items = new List<InventoryItem>();
    public StoryItem inventoryItemContainer;
    public InventoryItem storyItem;

    private void Start()
    {
        //items = FindObjectOfType<Inventory>().items;
        inventoryItemContainer = FindObjectOfType<StoryItem>();
        DestroyPreviouslyFoundStoryItem();
    }
    private void Update()
    {

    }

    private void DestroyPreviouslyFoundStoryItem()
    {/*
        foreach (InventoryItem item in items)
        {
            if (item.itemName == inventoryItemContainer.item.itemName && item.isFound)
            {
                Destroy(inventoryItemContainer);
                Destroy(inventoryItemContainer.gameObject);
                Debug.Log("Destroyed " + inventoryItemContainer.item.itemName);
            }
        }
        */

        if (storyItem.isFound)
        {
            Destroy(inventoryItemContainer);
            Destroy(inventoryItemContainer.gameObject);
            Debug.Log("Destroyed " + inventoryItemContainer.item.itemName);
        }
    }
}