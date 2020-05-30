using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionAccomplishedOnItemFound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MissionAccomplished();
    }

    void MissionAccomplished()
    {
        Inventory inventory = FindObjectOfType<Inventory>();
        InventoryItem inventoryItem = FindObjectOfType<LevelManager>().storyItem;
        if (inventory.items.Contains(inventoryItem))
        {
            gameObject.GetComponent<DialogueManager>().missionAccomplished = true;
        }
    }
}
