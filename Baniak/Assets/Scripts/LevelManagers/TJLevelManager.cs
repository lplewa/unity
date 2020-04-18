using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TJLevelManager : MonoBehaviour
{
    public AnswerOrder answerOrder;
    public DialogueManager dialogueManager;
    public Puzzle puzzle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (answerOrder.answerOrder.Count == 3)
        {
            if (answerOrder.CheckAnswerCorrect())
            {
                MissionComplete();
                puzzle.transform.gameObject.SetActive(false);
            }
            else MissionUncomplete();
            answerOrder.answerOrder.Clear();
        }
    }

    private void MissionUncomplete()
    {
        dialogueManager.GetComponent<NPC>().StartTalking();
        TJQuizButton[] quizButtons = FindObjectsOfType<TJQuizButton>();
        foreach(TJQuizButton button in quizButtons)
        {
            button.GetComponent<Button>().interactable = true;
        }
    }

    void MissionComplete()
    {
        dialogueManager.missionAccomplished = true;
        dialogueManager.GetComponent<NPC>().StartTalking();
    }

}
