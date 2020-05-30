﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Baniak_Controler;

public class EmptyTavernManager : MonoBehaviour
{
    public NPC dzieran;
    public NPC baniakText;
    public Baniak_Controler baniak;
    public Animator dialogueAnimator;
    public ActiveDailogue activeDailogue;
    public enum ActiveDailogue
    {
        DzieranSpeach,
        BaniakResponse,
        DzieranResponse,
        AllDailoguesStopped
    }
    private bool dzieranSpeachStarted;
    private bool baniakResponseStarted;
    private bool dzieranResponseStarted;

    public string nextLocationName;

    public void Start()
    {
        dzieranSpeachStarted = false;
        baniakResponseStarted = false;
        dzieranResponseStarted = false;
        activeDailogue = ActiveDailogue.DzieranSpeach;
        dialogueAnimator = FindObjectOfType<LevelManager>().dialogueAnimator;
    }

    private void Update()
    {
        ManageScene();
    }

    private void DzieranSpeach()
    {
        if(!dzieranSpeachStarted)
        {
            dzieranSpeachStarted = true;
            baniak.state = State.Talking;
            dzieran.StartTalking();
        }
        if (dzieran.dialogueStopped)
        {
            activeDailogue = ActiveDailogue.BaniakResponse;
        }
    }

    private void BaniakResponse()
    {
        if (!baniakResponseStarted)
        {
            baniakResponseStarted = true;
            dzieran.dialogueStopped = false;
            baniak.state = State.Talking;
            baniakText.StartTalking();
        }
        if (baniakText.dialogueStopped) activeDailogue = ActiveDailogue.DzieranResponse;
    }

    private void DzieranResponse()
    {
        if (!dzieranResponseStarted)
        {
            dzieranResponseStarted = true;
            baniak.state = State.Talking;
            dzieran.StartTalking();
        }
        if (dzieran.dialogueStopped) activeDailogue = ActiveDailogue.AllDailoguesStopped;
    }

   IEnumerator MoveToNextLocation(string locationName)
    {
        yield return new WaitForSeconds(1f);
            UnityEngine.SceneManagement.SceneManager.LoadScene(locationName);
 
    }

    private void ManageScene()
    {
        if (activeDailogue == ActiveDailogue.DzieranSpeach) DzieranSpeach();
        else if (activeDailogue == ActiveDailogue.BaniakResponse) BaniakResponse();
        else if (activeDailogue == ActiveDailogue.DzieranResponse) DzieranResponse();
        else if (activeDailogue == ActiveDailogue.AllDailoguesStopped) StartCoroutine(MoveToNextLocation(nextLocationName));
    }



}