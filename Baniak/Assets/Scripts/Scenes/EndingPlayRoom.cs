using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Baniak_Controler;

public class EndingPlayRoom : MonoBehaviour
{
    public NPC baniakText;
    public Baniak_Controler baniak;
    public Animator dialogueAnimator;
    private bool baniakSpeachStarted;

    public void Start()
    {
        baniakSpeachStarted = false;
    }
    
    private void Update()
    {
        BaniakSpeach();
    }

    private void BaniakSpeach()
    {
        if (!baniakSpeachStarted)
        {
            baniakSpeachStarted = true;
            baniak.state = State.Talking;
            baniakText.StartTalking();
        }
        if (baniakText.dialogueStopped) StartCoroutine(MoveToNextLocation("Outro"));
    }

    IEnumerator MoveToNextLocation(string locationName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(locationName);
    }
}
