using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private NPCDialogue dialogue;
    public bool dialogueStarted;
    public bool isRotating;
    public bool hasDialogueVariants;
    public Sprite avatar;

    private void Start()
    {
        dialogueManager = this.GetComponent<DialogueManager>();
        Debug.Log("NPC DialogueManager Set: " + dialogueManager);
        dialogue = GetComponent<DialogueTrigger>().dialogue;
        Debug.Log("NPC dialogue set: " + dialogue);
        dialogueStarted = false;
        Debug.Log("NPC dialogue started set: " + dialogueStarted);
       
    }
    private void Update()
    {
        if (dialogueStarted)
        {
            if (Input.GetKeyDown("space"))
                   {
                       this.dialogueManager.DisplayNextSentence();
                   }
        }
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartTalking();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartTalking();
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {

        StopTalking();
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        StopTalking();
    }
    
    public void StartTalking()
    {
        if (isRotating)
        {
            GetComponent<Animator>().SetBool("Speaking", true);
        }
        
        if (!hasDialogueVariants)
        {
            this.dialogueManager.StartDialogue(dialogue);

        }
        else
        {
            GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        dialogueStarted = true;
    }

    public void StopTalking()
    {
        Debug.Log("StopTalking Started");
        if (isRotating)
        {
            GetComponent<Animator>().SetBool("Speaking", false);
        }
        Debug.Log("End Collision");
        dialogueStarted = false;
        dialogueManager.dialogueAnimator.SetBool("isOpen", false);
        Debug.Log("StopTalking Stopped");
    }

    public void AddRewardToInventory()
    {
        bool rewardPreviouslyAdded;
        InventoryItem inventoryItem = FindObjectOfType<LevelManager>().storyItem;
        Inventory inventory = FindObjectOfType<Inventory>();
        if(inventory != null)
        {
            if (inventory.items.Contains(inventoryItem)) rewardPreviouslyAdded = true;
            else rewardPreviouslyAdded = false;
            if (inventoryItem != null)
            {
                if (dialogueManager.missionAccomplished && !rewardPreviouslyAdded)
                {
                    inventory.Add(inventoryItem);
                    inventoryItem.isFound = true;
                }
            }
        }
    }
}
