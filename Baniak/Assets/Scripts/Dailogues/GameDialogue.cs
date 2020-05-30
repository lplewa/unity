using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDialogue : MonoBehaviour
{
    public NPC succesDialog;
    public Portal portal;

    // Start is called before the first frame update
    void Start()
    {
        succesDialog = GetComponentInParent<NPC>();
    }

    // Update is called once per frame
    void Update()
    {
        if (portal.transform.gameObject.active)
        {
            ShowMessage();
        }    
    }

    void SuccessMessage()
    {
        succesDialog.GetComponent<DialogueTrigger>().dialogue.characterName = "Nemi";
        succesDialog.GetComponent<DialogueTrigger>().dialogue.sentences[0] = "Portal! Otworzyłeś portal! ";
        succesDialog.GetComponent<DialogueTrigger>().dialogue.sentences[1] = "W każdej chwili, kiedy będziesz chciał ponownie z niego skorzystać po prostu wciśnij P ";
    }

    
    void ShowMessage()
    {
        SuccessMessage();
        succesDialog.StartTalking();
            Destroy(gameObject);
    }
}
