using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInventory : MonoBehaviour
{
    void Start()
    {
        InventoryCanvas inventory = FindObjectOfType<InventoryCanvas>();
        if (inventory != null) Destroy(inventory.gameObject);

    }

}
