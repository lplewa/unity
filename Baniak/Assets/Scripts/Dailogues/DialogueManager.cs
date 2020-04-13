using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Text nameText;
    private Text dialogueText;
    public Queue<string> sentences;
    public Animator dialogueAnimator;
    public bool dialogueEnded;
    public bool missionAccomplished;
    private Baniak_Controler baniak;
    public string NPCName;

    // Start is called before the first frame update
    void Start()
    {
        baniak = FindObjectOfType<Baniak_Controler>();

        sentences = new Queue<string>();

        nameText = FindObjectOfType<LevelManager>().characterName;

        dialogueText = FindObjectOfType<LevelManager>().lines;
     
        dialogueAnimator = FindObjectOfType<LevelManager>().dialogueAnimator;

        NPCName = gameObject.name;

    }

    public void StartDialogue(NPCDialogue dialogue)
    {
        gameObject.GetComponent<NPC>().AddRewardToInventory();
        Debug.Log("Dialogue Manager: Starting conversation with " + dialogue.characterName);
        dialogueAnimator.SetBool("isOpen", true);
        nameText.text = dialogue.characterName;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            Debug.Log("DialogueManager: enqueque sentence: " + sentence);
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        Debug.Log("DisplayNextSentence: Display nest sentence started");
        Debug.Log("DisplayNextSentence SETNENCES:" + sentences.Count);
        if (sentences.Count == 0)
        {
            Debug.Log("sentences.Count == 0");
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines(); //żeby nam się animacja nie zamknęła podczas przewijania tekstu
        StartCoroutine(TypeSentence(sentence));
        Debug.Log("sentences.Count == "+sentences.Count);
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Debug.Log("Endialogue Started");
        dialogueAnimator.SetBool("isOpen", false);
        if(baniak != null){
            baniak.state = Baniak_Controler.State.Moving;
        }
        GetComponent<NPC>().StopTalking();
        dialogueEnded = true;
        Debug.Log("Endialogue Stopped");
    }

    public void SetupDialogueEnded()
    {
        DialoguesEndedCollector dialoguesEndedCollector =FindObjectOfType<DialoguesEndedCollector>();
        if(dialoguesEndedCollector != null){
            if (dialoguesEndedCollector.firstDialogueEnded.Contains(NPCName))
            {
                dialogueEnded = true;
            }
            if (dialoguesEndedCollector.missionsAccomplished.Contains(NPCName))
            {
                missionAccomplished = true;
            }
            
        }
    }
}
