using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private NPCDialogue dialogue;
    private bool dialogueStarted;
    public bool isRotating;

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
        this.dialogueManager.StartDialogue(dialogue);
        dialogueStarted = true;
    }

    private void StopTalking()
    {
        if (isRotating)
        {
            GetComponent<Animator>().SetBool("Speaking", false);
        }
        Debug.Log("End Collision");
        dialogueStarted = false;
        dialogueManager.dialogueAnimator.SetBool("isOpen", false);
    }
}
