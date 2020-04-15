using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Baniak_Controler;

public class TavernManager : MonoBehaviour
{
    private NPC[] npcs;
    public Portal portal;
    public DialogueTrigger dialogueTrigger;
    public NPC dialogueInfo;
    public Baniak_Controler baniak;
    public GameObject controlsHint;

    // Start is called before the first frame update
    void Start()
    {
        controlsHint.transform.gameObject.SetActive(false);
        dialogueInfo.transform.gameObject.SetActive(false);
        npcs = FindObjectsOfType<NPC>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!portal.transform.gameObject.active)
        {
            if (CheckAllDialoguesEnded())
            {
                SetPortalActive();
                NemiPortalInfo();
            }
             }
    }

    void SetPortalActive()
    {
        portal.transform.gameObject.SetActive(true);
    }
   
    bool CheckAllDialoguesEnded()
    {
        bool ended = true;
        foreach(NPC npc in npcs)
        {
            if (!npc.GetComponent<DialogueManager>().missionStarted)
            {
                ended = false;
            }
        }
        Debug.Log("All have spoken");
        return ended;
    }

    void NemiPortalInfo()
    {
        DialogueTrigger dialogueTrigger = dialogueInfo.GetComponent<DialogueTrigger>();
        dialogueInfo.transform.gameObject.SetActive(true);
        dialogueTrigger.dialogue.characterName = "Nemi";
        dialogueTrigger.dialogue.sentences[0] = "To portal! Za każdym razem, kiedy będziesz go potrzebował, wciśnij P";
        baniak.state = State.Talking;
        dialogueInfo.StartTalking();
        controlsHint.transform.gameObject.SetActive(true);

    }
}
