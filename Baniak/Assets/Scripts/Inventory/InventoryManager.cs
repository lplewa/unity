using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    public InventoryUI inventoryUi;

    private void Awake()
    {
        inventoryUi = FindObjectOfType<InventoryCanvas>().GetComponentInChildren<InventoryUI>();
    }

    void Start()
    {

    }
    private void Update()
    {


    }
    
}
