using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    public CoinItem coin;
    public NPC succesDialog;

    // Start is called before the first frame update
    void Start()
    {
        succesDialog = GetComponentInParent<NPC>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickupCoin();
    }

    void PickupCoin()
    {
        SuccessMessage();
        succesDialog.StartTalking();
        Debug.Log("Pick up the coin into inventory " + coin.coinName);
        bool wasPickedUp = CoinCollector.instance.Add(coin);
        if (wasPickedUp)
        {
            coin.isFound = true;
            Destroy(gameObject);
        }

    }

    void SuccessMessage()
    {
        succesDialog.GetComponent<DialogueTrigger>().dialogue.characterName = "Baniak";
        succesDialog.GetComponent<DialogueTrigger>().dialogue.sentences[0] = "To moneta dla ciotki Claytona!";
    }
}
