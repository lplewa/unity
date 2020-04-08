using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    #region Singleton

    public static CoinCollector instance;
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
    public delegate void OnCoinItemChanged();
    public OnCoinItemChanged OnCoinChangedCallback;
    public int space = 5;
    public List<CoinItem> coins = new List<CoinItem>();

    public bool Add(CoinItem item)
    {
        if (coins.Count >= space)
        {
            Debug.Log("Not Enough room");
            return false;
        }
        coins.Add(item);
        if (OnCoinChangedCallback != null)
        {
            OnCoinChangedCallback.Invoke();
        }

        return true;
    }
    public static CoinCollector GetCoinCollectorInstance()
    {
        return instance;
    }
}
