﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Baniak_Controler;

public class CoinPickup : MonoBehaviour
{

    public CoinItem coin;
    public NPC succesDialog;
    private bool missionStarted;
    private Baniak_Controler baniak;

    // Start is called before the first frame update
    void Start()
    {
        succesDialog = GetComponentInParent<NPC>();
        baniak = FindObjectOfType<Baniak_Controler>();
        missionStarted = succesDialog.GetComponent<DialogueManager>().missionStarted;
        
    }

    // Update is called once per frame
    void Update()
    {
      ///  succesDialog.GetComponent<DialogueTrigger>()
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            PickupCoin();
    }

    void PickupCoin()
    {
        List<string> missionsStarted = FindObjectOfType<DialoguesEndedCollector>().startedMissions;
        if (missionsStarted.Contains("Aunt"))
        {
            baniak.state = State.Talking;
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
    }

    void SuccessMessage()
    {
        succesDialog.GetComponent<DialogueTrigger>().dialogue.characterName = "Baniak";
        succesDialog.GetComponent<DialogueTrigger>().dialogue.sentences[0] = "To moneta dla ciotki Claytona!";
    }

}
