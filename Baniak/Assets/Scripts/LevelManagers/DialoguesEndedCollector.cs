using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguesEndedCollector : MonoBehaviour
{
    #region Singleton

    public static DialoguesEndedCollector instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of DialoguesEndedCollector found");
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    #endregion

  //  public int space = 5;
    public List<string> firstDialogueEnded;
    public List<string> missionsAccomplished;

    void Start()
    {
        firstDialogueEnded = new List<string>();
        missionsAccomplished = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        AddEndedDialogue();
    }

    void AddEndedDialogue()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if (levelManager != null)
        {
            if (levelManager.npc != null)
            {
                DialogueManager dialogueManager = levelManager.npc;
                bool dialogueEnded = dialogueManager.dialogueEnded;
                string NPCName = dialogueManager.gameObject.name;
                bool shouldBeAdded = true;
                if (firstDialogueEnded.Contains(NPCName)) shouldBeAdded = false;
                if (dialogueEnded && shouldBeAdded)
                {
                    firstDialogueEnded.Add(NPCName);
                }
            }
        }
    }

    void AddMissionAccomplished()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if (levelManager.npc != null)
        {
            DialogueManager dialogueManager = levelManager.npc;
            bool missionAccomplished = dialogueManager.missionAccomplished;
            string NPCName = dialogueManager.gameObject.name;
            bool shouldBeAdded = true;
            if (missionsAccomplished.Contains(NPCName)) shouldBeAdded = false;
            if (missionAccomplished && shouldBeAdded)
            {
                firstDialogueEnded.Add(NPCName);
            }
        }
    }
}
