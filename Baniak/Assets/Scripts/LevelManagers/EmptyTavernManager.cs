using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Baniak_Controler;

public class EmptyTavernManager : MonoBehaviour
{
    public NPC dzieran;
    public Baniak_Controler baniak;
    private bool dzieranSpoken;

    public void Start()
    {
        dzieranSpoken = false;
    }

    private void Update()
    {
        DzieranSpeach();
    }

    private void DzieranSpeach()
    {
        if (!dzieranSpoken)
        {
            baniak.state = State.Talking;
            dzieran.StartTalking();
            dzieranSpoken = true;
        }

    }
}