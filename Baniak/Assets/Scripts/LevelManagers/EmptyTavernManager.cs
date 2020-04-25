using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Baniak_Controler;

public class EmptyTavernManager : MonoBehaviour
{
    public NPC dzieran;
    public NPC baniakText;
    public Baniak_Controler baniak;
    private bool dzieranSpoken;
    private bool baniakAnswered;

    public void Start()
    {
        dzieranSpoken = false;
        baniakAnswered = false;
    }

    private void Update()
    {
        DzieranSpeach();
       BaniakResponse();
        MoveToGamesRoom();
    }

    private void DzieranSpeach()
    {
        if (!dzieran.dialogueManager.missionStarted && !dzieranSpoken)
        {
            baniak.state = State.Talking;
            dzieran.StartTalking();
            dzieranSpoken = true;
                    }
    }

    private void BaniakResponse()
    {
        if (dzieranSpoken && !baniakAnswered && dzieran.dialogueManager.missionStarted)
        {
            baniak.state = State.Talking;
            baniakText.StartTalking();
            baniakAnswered = true;
        }
    }

    private void MoveToGamesRoom()
    {
        if(dzieran.dialogueManager.missionStarted && baniakText.dialogueManager.missionStarted)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Games Room Fight");
        }
    }
}