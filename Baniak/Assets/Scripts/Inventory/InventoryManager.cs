using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    public InventoryUI inventoryUI;                     
    public bool hideInventory;

    void Start()
    {
        SetupInventoryUI();
        EnableOrDisableInventoryUi();
    }

    private void SetupInventoryUI()
    {
        var inactiveGroup = Resources.FindObjectsOfTypeAll<InventoryUI>();
        if (inactiveGroup.Length > 0)
        {
            inventoryUI = inactiveGroup[0];
        }
        else
        {
            inventoryUI = FindObjectOfType<InventoryUI>();
        }
    }

    private void Update()
    {
        SetupInventoryUI();
        EnableOrDisableInventoryUi();
    }

    private void EnableOrDisableInventoryUi()
    {
        if (inventoryUI != null)
        {
            if (hideInventory)
            {
                inventoryUI.transform.gameObject.SetActive(false);
                Debug.Log("Inventory visibility changed to false");
            }
            else
            {
                inventoryUI.transform.gameObject.SetActive(true);
                Debug.Log("Inventory visibility changed to false");

            }
        }
    }
}
