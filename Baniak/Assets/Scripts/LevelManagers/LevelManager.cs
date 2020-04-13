using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public DialogueManager npc;
    public GameObject ui;
    public Text characterName;
    public Text lines;
    public Animator dialogueAnimator;
    public StoryItem inventoryItemContainer;
    public InventoryItem storyItem;
    public CoinPickup coinPickup;
    public CoinItem coin;
    public Portal portal;
    public bool winCondition;

    private void Start()
    {
        SetPortalInactive();
        inventoryItemContainer = FindObjectOfType<StoryItem>();
        coinPickup = FindObjectOfType<CoinPickup>();
        DestroyPreviouslyFoundStoryItem();
        DestroyPreviouslyFoundCoin();
    }
    private void Update()
    {
        ShowPortal();
    }

    private void DestroyPreviouslyFoundStoryItem()
    {
        if (storyItem != null)
        {
            if (storyItem.isFound)
            {
                if(inventoryItemContainer != null)
                {
                    Destroy(inventoryItemContainer);
                    Destroy(inventoryItemContainer.gameObject);
                    Debug.Log("Destroyed " + inventoryItemContainer.item.itemName);
                }
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
    void SetPortalInactive()
    {
        if (portal!=null)portal.transform.gameObject.SetActive(false);
    }
    private void ShowPortal()
    {
        if (Input.GetKeyDown("p")&& portal!=null)
        {
            portal.transform.gameObject.SetActive(true);
        }
    }
}