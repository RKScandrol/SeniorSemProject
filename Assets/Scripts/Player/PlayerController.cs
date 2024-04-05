using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    // Player attributes
    public float moveSpeed = 20.0f;


    //Trying to (mostly) handle animations in code, let's see how it goes!
    public Animator animator;

    //Point of reference for attack
    public Transform attackPoint;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {   
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
       
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);

        //Plays walk animation and updates attack point based on direction
        if (rb.velocity.y > 0.1)
        {
            attackPoint.position = new Vector2(rb.transform.position.x, rb.position.y + 0.5f);
            animator.Play("player_walk_U");
        }
        else if (rb.velocity.y < -0.1 && rb.velocity.x == 0) {
            attackPoint.position = new Vector2(rb.transform.position.x, rb.position.y - 0.5f);
            animator.Play("player_walk_D");
        }
        else if (rb.velocity.x < -0.1)
        {
            attackPoint.position = new Vector2(rb.transform.position.x - 0.5f, rb.position.y);
            animator.Play("player_walk_L");
        }
        else if (rb.velocity.x > 0.1)
        {
            attackPoint.position = new Vector2(rb.transform.position.x + 0.5f, rb.position.y);
            animator.Play("player_walk_R");
        }
        
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        rb.velocity = new Vector2(horizontal * moveSpeed * Time.fixedDeltaTime * 5, vertical * moveSpeed * Time.fixedDeltaTime * 5);
    }


    /*
        Boosts MoveSpeed by a Percentage
        Does not let MoveSpeed become greater than a max value
    */
    public float boostMoveSpeedByPercent(double percent) {

        float max = 150.00f;

        float increase = moveSpeed * (float)percent;
        if (moveSpeed + increase > max) {
            moveSpeed = max;
        }
        else {
            moveSpeed += increase;
        }
        return moveSpeed;
    }

    /*
        Drops MoveSpeed by a Percentage
        Returns False if the MoveSpeed was not dropped due to it already being too low
        Returns True if the MoveSpeed was dropped
    */
    public bool dropMoveSpeedByPercent(float percent) {

        float min = 1.0f;

        if ( Math.Abs(moveSpeed - min) <= 0.01 ) {
            return false;
        }
        
        float decrease = moveSpeed * percent;

        if (moveSpeed - decrease < min) {
            moveSpeed = min;
            return true;
        }
        else {
            moveSpeed -= decrease;
            return true;
        }

    }
    
}