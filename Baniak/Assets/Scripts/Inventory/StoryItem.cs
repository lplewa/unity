﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Baniak_Controler;

public class StoryItem : MonoBehaviour
{
    public InventoryItem item;
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
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Pickup();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Pickup();
    }

    void Pickup()
    {
        List<string> missionsStarted = FindObjectOfType<DialoguesEndedCollector>().startedMissions;
        string NPCName = FindObjectOfType<LevelManager>().npc.gameObject.name;
        Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! " + NPCName);
        if (missionsStarted.Contains(NPCName))
        {
            baniak.state = State.Talking;
            SuccessMessage();
            succesDialog.StartTalking();
            Debug.Log("Pick up the item into inventory " + item.itemName);
            bool wasPickedUp = Inventory.instance.Add(item);
            if (wasPickedUp)
            {
                item.isFound = true;
                Destroy(gameObject);
            }
        }
    }

    void SuccessMessage()
    {
        succesDialog.GetComponent<DialogueTrigger>().dialogue.characterName = "Baniak";
        succesDialog.GetComponent<DialogueTrigger>().dialogue.sentences[0]="Przecież to " + item.itemName;
    }
}
