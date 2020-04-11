using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public NPCDialogue dialogue;
    public NPCDialogue missionNotAccomplishedDialogue;
    public NPCDialogue successDialogue;


    public void TriggerDialogue()
    {
        DialogueManager dialogueObject = FindObjectOfType<DialogueManager>();
        if (!dialogueObject.dialogueEnded)
        {
            dialogueObject.StartDialogue(dialogue);
        }else if (!dialogueObject.missionAccomplished)
        {
            dialogueObject.StartDialogue(missionNotAccomplishedDialogue);
        }
        else
        {
            dialogueObject.StartDialogue(successDialogue);
        }

    }
}
