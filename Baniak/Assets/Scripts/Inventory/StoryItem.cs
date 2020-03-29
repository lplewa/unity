using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StoryItem : MonoBehaviour
{
    public InventoryItem item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Pickup();
    }
    void Pickup()
    {
        Debug.Log("Pick up the item into inventory "+item.itemName);
        bool wasPickedUp=Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
