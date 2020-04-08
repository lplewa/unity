using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCoinsCount : MonoBehaviour
{
    private CoinCollector coinCollector;
    public Text coinsText;

    // Start is called before the first frame update
    void Start()
    {
        coinsText.GetComponent<Text>().text = coinCollector.coins.Count.ToString() + coinCollector.space.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        coinsText.GetComponent<Text>().text = coinCollector.coins.Count.ToString() + coinCollector.space.ToString();
        
    }


}
