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

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    

    // Update is called once per frame
    void Update()
    {
       horizontal = Input.GetAxisRaw("Horizontal");
       vertical = Input.GetAxisRaw("Vertical");
       
       animator.SetFloat("Horizontal", horizontal);
       animator.SetFloat("Vertical", vertical);
    }

    void FixedUpdate()
    {   
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        rb.velocity = new Vector2(horizontal * moveSpeed * Time.fixedDeltaTime * 5, vertical * moveSpeed * Time.fixedDeltaTime * 5);
        
        //Plays walk animation based on direction
        if (rb.velocity.y > 0)
        {
            animator.Play("guy_walk_U");
        }
        else if (rb.velocity.y < 0 && rb.velocity.x == 0) {
            animator.Play("guy_walk_D");
        }
        else if (rb.velocity.x < 0)
        {
            animator.Play("guy_walk_L");
        }
        else if (rb.velocity.x > 0)
        {
            animator.Play("guy_walk_R");
        }
    }
    
}