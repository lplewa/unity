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
    public StoryItem inventoryItemContainer;
    public InventoryItem storyItem;
    public CoinPickup coinPickup;
    public CoinItem coin;

    private void Start()
    {
        inventoryItemContainer = FindObjectOfType<StoryItem>();
        coinPickup = FindObjectOfType<CoinPickup>();
        DestroyPreviouslyFoundStoryItem();
        DestroyPreviouslyFoundCoin();
    }
    private void Update()
    {

    }

    private void DestroyPreviouslyFoundStoryItem()
    {
        if (storyItem != null)
        {
            if (storyItem.isFound)
            {
                Destroy(inventoryItemContainer);
                Destroy(inventoryItemContainer.gameObject);
                Debug.Log("Destroyed " + inventoryItemContainer.item.itemName);
            }
        }

    }

    private void DestroyPreviouslyFoundCoin()
    {
        if (coinPickup != null)
        {
            if (coin.isFound)
            {
                Destroy(coinPickup);
                Destroy(coinPickup.gameObject);
                Debug.Log("Destroyed " + coinPickup.coin.coinName);
            }
        }
    }
}