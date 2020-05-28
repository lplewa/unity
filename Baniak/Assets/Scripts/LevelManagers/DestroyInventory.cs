using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInventory : MonoBehaviour
{
    CoinCollector coinCollector;
    Inventory inventory;
    DialoguesEndedCollector dialoguesEndedCollector;

    void Start()
    {
        InventoryCanvas Canvas = FindObjectOfType<InventoryCanvas>();
        if (Canvas != null) Destroy(Canvas.gameObject);

        coinCollector = FindObjectOfType<CoinCollector>();
        Destroy(coinCollector.gameObject);

    }

}
