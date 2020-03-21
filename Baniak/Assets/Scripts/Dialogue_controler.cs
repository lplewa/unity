using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Dialouge;
public class Dialogue_controler : MonoBehaviour
{
    Queue<Sentence> sentences;
    public Text Name;
    public Text Line;
    private bool type = false;

    Dialogue_controler() => sentences = new Queue<Sentence>();

    // Start is called before the first frame update
    public void Start_dialogue(Dialouge dialouge)
    {
        if (sentences == null) {
            sentences = new Queue<Sentence>();
        }
        sentences.Clear();


        foreach (Sentence s in dialouge.sentences) {
            sentences.Enqueue(s);
        }
        NextSentence();
    }

    public bool NextSentence() {
        if (type == true)
            return false;

        if (sentences.Count == 0) {
            Name.text = "";
            Line.text = "";
            return true;
        }


        type = true;
        Sentence sentence = sentences.Dequeue();
        Name.text = sentence.name;
        StartCoroutine(TypeSentence(sentence.line));
        return false;
    }

    IEnumerator TypeSentence(string sentence) {
        Line.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            Line.text += letter;
            yield return null;
        }
        type = false;
    }
}
