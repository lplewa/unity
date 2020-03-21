using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dialouge : MonoBehaviour
{
    [System.Serializable]
    public class Sentence
    {
        [SerializeField, TextArea(2, 5)]
        public string line;
        [SerializeField]
        public string name;
    }

    public Sentence[] sentences;
}

