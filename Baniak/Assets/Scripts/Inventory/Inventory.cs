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
    public WinPortal winPortalPrefab;

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

    private void Start()
    {
        WinPortal winPortal = FindObjectOfType<WinPortal>();
        if (winPortal != null)
        {
            Destroy(winPortal);
        }
    }

    private void Update()
    {
        AllStoryItemsCollected();
    }

    public void AllStoryItemsCollected()
    {
        WinPortal winPortal = FindObjectOfType<WinPortal>();
        if (items.Count == space)
        {
            if (winPortal == null)
            {
                LevelManager levelManager = FindObjectOfType<LevelManager>();
                if(levelManager.winPortalAvailable)
                {
                    Instantiate(winPortalPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                }
            }
        }
    }

}
 