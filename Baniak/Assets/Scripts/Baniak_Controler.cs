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
    public Animator animator = null;
    private Vector2 face = Vector2.down;
    public Dialogue_controler dialogue_Controler = null;
    public State state;
    private string direction;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dialogue_Controler = GetComponent<Dialogue_controler>();
        direction = "down";
        animator.SetBool("Standing", true);
    }

    // Update is called once per frame
    private void Update()
    {
         if (state == State.Moving) {
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
            animator.SetBool("Standing", false);
            if (horizontalInput > 0)
            {
                animator.SetInteger("MoveDirection", 2);
                direction = "right";
            }
            else
            {
                animator.SetInteger("MoveDirection", 1);
                direction = "left";
            }
        }
       else if (verticalInput != 0)
        {
            animator.SetBool("Standing", false);
            if (verticalInput > 0)
            {
                animator.SetInteger("MoveDirection", 3);
                direction = "up";
            }
            else
            {
                animator.SetInteger("MoveDirection", 4);
                direction = "down";
            } 
        }
        else
        {
            animator.SetBool("Standing", true);
        }
    }

    void talk()
    {
    }

}
