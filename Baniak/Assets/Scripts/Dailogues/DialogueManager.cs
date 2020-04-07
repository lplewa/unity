﻿using System;
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

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        nameText = FindObjectOfType<LevelManager>().characterName;
        dialogueText = FindObjectOfType<LevelManager>().lines;
        dialogueAnimator = FindObjectOfType<LevelManager>().dialogueAnimator;
    }

    public void StartDialogue(NPCDialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.characterName);
        dialogueAnimator.SetBool("isOpen", true);
        nameText.text = dialogue.characterName;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines(); //żeby nam się animacja nie zamknęła podczas przewijania tekstu
        StartCoroutine(TypeSentence(sentence));
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
        Debug.Log("End of conversation");
        dialogueAnimator.SetBool("isOpen", false);
    }
}