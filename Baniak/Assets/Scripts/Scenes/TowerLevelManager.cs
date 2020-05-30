using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLevelManager : MonoBehaviour
{
    public Puzzle puzzle;
    public DialogueManager dialogueManager;
    public Baniak_Controler baniak;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActivatePuzzle();
    }

    void ActivatePuzzle()
    {
        if(dialogueManager.missionStarted && !dialogueManager.missionAccomplished)
        {
            puzzle.transform.gameObject.SetActive(true);
            baniak.state = Baniak_Controler.State.Talking;
        }

    }

}
