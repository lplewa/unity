using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public NPCDialogue dialogue;
    public bool isSpeaking;

    private void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
        dialogue = GetComponent<DialogueTrigger>().dialogue;
        isSpeaking = false;
    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            this.dialogueManager.DisplayNextSentence();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("NPC Collision");
        isSpeaking = true;
        this.dialogueManager.StartDialogue(dialogue);
    }

}
