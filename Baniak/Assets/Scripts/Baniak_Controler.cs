using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Baniak_Controler : MonoBehaviour
{
    public enum State
    {
        Moving,
        Talking,
    }


    public float speed = 6.0f;
    public float movementSpeed = 4.5f;
    private Rigidbody2D rb = null;
    private Animator animator = null;
    private Vector2 face = Vector2.down;
    public Dialogue_controler dialogue_Controler = null;
    public State state;


    void Start()
    {
        state = State.Moving;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dialogue_Controler = GetComponent<Dialogue_controler>();
    }

    // Update is called once per frame
    private void Update()
    {
         if (state == State.Moving) {
             //move();
            Move();
         }

         if (state == State.Talking)
         {
             talk();
         }
    
    }
     void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);
        SetMoveAnimation();
    }

    void SetMoveAnimation()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0)
        {
            if (horizontalInput > 0) animator.SetInteger("MoveDirection", 2);
            else animator.SetInteger("MoveDirection", 1);
        }
        if (verticalInput != 0)
        {
            if(verticalInput>0) animator.SetInteger("MoveDirection", 3);
            else animator.SetInteger("MoveDirection", 4);
        }
    }
    /*
    public void startDialouge(Dialouge dialouge)
    {
        state = State.Talking;
        this.dialogue_Controler.Start_dialogue(dialouge);
    }*/

    void talk()
    {/*
        if (Input.anyKeyDown) {
            if (dialogue_Controler.NextSentence()) {
                state = State.Moving;
            }
        }
        */
    }

}
