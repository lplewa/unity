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
  /*  void move()
    {
        rb.velocity = Vector2.zero;
     //   rb.angularVelocity = 0;
        Vector2 moveDirection = Vector2.zero;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x != 0 && y != 0)
            return; /*no diagonal movement 

        if (x != 0) {
            if (x > 0) {
                face = Vector2.right;
                animator.SetInteger("MoveDirection", 2);
            } else {
                face = Vector2.left;
                animator.SetInteger("MoveDirection", 1);
            }
        }

        if (y != 0) {
            if (y > 0) {
                face = Vector2.up;
                animator.SetInteger("MoveDirection", 3);
            } else {
                face = Vector2.down;
                animator.SetInteger("MoveDirection", 4);
            }
        }

        moveDirection = new Vector2(x, y);
        moveDirection *= speed;
        rb.velocity = moveDirection;

        if (Input.GetButtonDown("Fire1")) {
            int mask = LayerMask.GetMask("interakcja");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, face, 10, mask);
            if (hit) {
                GameObject obj = hit.collider.gameObject;
                Dialouge d = obj.GetComponent<Dialouge>();
                if (d != null) {
                    startDialouge(d);
                }
            }
        }
    }
    */
    public void startDialouge(Dialouge dialouge)
    {
        state = State.Talking;
        this.dialogue_Controler.Start_dialogue(dialouge);
    }

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
