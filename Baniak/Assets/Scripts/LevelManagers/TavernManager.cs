using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Baniak_Controler;

public class TavernManager : MonoBehaviour
{
    private NPC[] npcs;
    public Portal portalPrefab;
    public NPC dialogueInfo;
    public DialogueManager dialogueManager;
    public Baniak_Controler baniak;
    public GameObject controlsHint;
    private bool portalInfoDisplayed;

    // Start is called before the first frame update
    void Start()
    {
        controlsHint.transform.gameObject.SetActive(false);
        npcs = FindObjectsOfType<NPC>();
        portalInfoDisplayed = false;
    }

    // Update is called once per frame
    void Update()
    {
            if (CheckAllDialoguesEnded())
            {
                InstantinatePortal();
                NemiPortalInfo();
            }
    }

    void InstantinatePortal()
    {
        Portal portal = FindObjectOfType<Portal>();
        if(portal==null)
        {
            Instantiate(portalPrefab, new Vector3(-1, 7, 0), Quaternion.identity);
        }
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
        if (!portalInfoDisplayed) {
            dialogueManager.missionAccomplished = true;
            baniak.state = State.Talking;
            dialogueInfo.StartTalking();
            controlsHint.transform.gameObject.SetActive(true);
            portalInfoDisplayed = true;
        }
    }
}
