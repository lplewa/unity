using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC : MonoBehaviour
{
    private DialogueManager dialogueManager;
    public NPCDialogue dialogue;
    private bool dialogueStarted;

    private void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
        dialogue = GetComponent<DialogueTrigger>().dialogue;
        dialogueStarted = false;
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
        Debug.Log("NPC Collision");
        this.dialogueManager.StartDialogue(dialogue);
        dialogueStarted = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("NPC Collision");
        this.dialogueManager.StartDialogue(dialogue);
        dialogueStarted = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("End Collision");
        dialogueStarted = false;
        dialogueManager.dialogueAnimator.SetBool("isOpen", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("End Trigger");
        dialogueStarted = false;
        dialogueManager.dialogueAnimator.SetBool("isOpen", false);
    }
}
