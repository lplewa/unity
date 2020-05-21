using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDialogues : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private NPCDialogue dialogue;
    public string nextScene;
   
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
        dialogue = GetComponent<DialogueTrigger>().dialogue;
        this.dialogueManager.StartDialogue(dialogue);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            this.dialogueManager.DisplayNextSentence();
        }

        if (dialogueManager.missionStarted)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
        }
    }
}
