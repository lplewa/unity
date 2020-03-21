using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_game : MonoBehaviour
{
    // Start is called before the first frame update
    public Baniak_Controler baniak;
    void Start()    {

        Dialouge dialouge = this.GetComponent<Dialouge>();
        baniak.startDialouge(dialouge);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
