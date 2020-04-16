using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizButton : MonoBehaviour
{
    [SerializeField] private bool isGood;

    public void CheckAnswer()
    {
        DialogueManager dialogueManager = new DialogueManager();
        dialogueManager = FindObjectOfType<LevelManager>().npc;
        if (isGood)
        {
            dialogueManager.missionAccomplished = true;
            Puzzle puzzle = FindObjectOfType<Puzzle>();
            puzzle.transform.gameObject.SetActive(false);

        }
        dialogueManager.GetComponent<NPC>().StartTalking();
    }
}
