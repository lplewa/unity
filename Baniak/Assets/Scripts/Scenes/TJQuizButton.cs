using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TJQuizButton : MonoBehaviour
{
    public Text spellText;
    private string buttonText;
    public int orderID;

    public void AddTextToSpell()
    {
        buttonText = gameObject.GetComponentInChildren<Text>().text;
        string newText= spellText.text + buttonText+ " ";
        spellText.text = newText;
        gameObject.GetComponent<Button>().interactable = false;
        FindObjectOfType<AnswerOrder>().answerOrder.Add(orderID);
    }
}

