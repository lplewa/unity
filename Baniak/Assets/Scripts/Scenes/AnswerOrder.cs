using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerOrder : MonoBehaviour
{
    public List<int> answerOrder=new List<int>();

    public bool CheckAnswerCorrect()
    {
            if (answerOrder[0] == 1 && answerOrder[1] == 2 && answerOrder[2] == 3) return true;
            else return false;
    }
}
