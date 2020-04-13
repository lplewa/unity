using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernManager : MonoBehaviour
{
    private NPC[] npcs;
    public Portal portal;

    // Start is called before the first frame update
    void Start()
    {
        
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
            if (!npc.GetComponent<DialogueManager>().dialogueEnded)
            {
                ended = false;
            }
        }
        Debug.Log("All have spoken");
        return ended;
    }

}
