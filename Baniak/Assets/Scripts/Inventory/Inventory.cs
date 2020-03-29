﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More tha one instance of inventory found");
            return;
        }

        instance = this;
    }
    #endregion
    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;

    public int space = 5;

    public List<InventoryItem> items = new List<InventoryItem>(); 

    public bool Add(InventoryItem item)
    {
        if(items.Count>=space)
        {
            Debug.Log("Not Enough room");
            return false;
        }
        items.Add(item);
        if (OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }
  
        return true;
    }
}
 