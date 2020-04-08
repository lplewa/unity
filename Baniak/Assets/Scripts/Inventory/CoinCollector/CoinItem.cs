using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Coin", menuName = "CoinCollector/Coin")]
public class CoinItem : ScriptableObject
{
    public Sprite icon;
    public string coinName;
    public bool isFound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}