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
        GetComponent<DialogueManager>().SetupDialogueEnded();
        GetComponent<DialogueManager>().StartDialogue(FindDialogue());
    }

    public NPCDialogue FindDialogue()
    {
        DialogueManager dialogueObject = GetComponent<DialogueManager>();
        if (!dialogueObject.missionStarted) return dialogue;
        else if (!dialogueObject.missionAccomplished) return missionNotAccomplishedDialogue;
        else return successDialogue;
    }
}
