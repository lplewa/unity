using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found");
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    #endregion
    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;
    public int space = 5;
    public List<InventoryItem> items = new List<InventoryItem>();
    public bool allStoryItemsCollected;

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
    public static Inventory GetInventoryInstance()
    {
        return instance;
    }


    private void Update()
    {
        AllStoryItemsCollected();
    }

    public void AllStoryItemsCollected()
    {
        if (items.Count == space)
        {
           var winPortals = Resources.FindObjectsOfTypeAll<WinPortal>();
            WinPortal winPortal;
            if (winPortals.Length > 0)
            {
                winPortal = winPortals[0];
                winPortal.gameObject.SetActive(true);
            }
            allStoryItemsCollected = true;
        }
    }

}
 