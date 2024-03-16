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
    public float maxHealth = 100.0f;
    public float currentHealth;
    public float damage = 10.0f;


    //Trying to (mostly) handle animations in code, let's see how it goes!
    public Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        //Set all player attributes to their proper values
        modifyDamage(getPermStatus("damage"));
        modifyMaxHealth(getPermStatus("maxHealth"));
        modifyMoveSpeed(getPermStatus("moveSpeed"));
        setCurrentHealth(maxHealth);

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

    //Gets a value from Json as a float based on a given name of that attribute.
    float getPermStatus(String statName)
    {
        //TODO: get JSON as float;

        return 1;
    }

    //Modifies the movement speed of the character by multiplying it by some float value.
    void modifyMoveSpeed(float mod)
    {
        moveSpeed *= mod;
    }

    //Modifies the base damage of the character by multiplying it by some float value.
    void modifyDamage(float mod)
    {
        damage *= mod;
    }

    //Modifies the max health of the character my multiplying it by some float value.
    void modifyMaxHealth(float mod)
    {
        maxHealth *= mod;
    }

    //Modifies the current health value by adding a certain float to it.
    void modifyCurrentHealth(float mod)
    {
        currentHealth += mod;
    }

    //Sets the current health to a desired value (used mainly for initialization of the character.)
    void setCurrentHealth(float val)
    {
        if(val>maxHealth)
        {
            currentHealth = maxHealth;
        }else
        {
            currentHealth = val;
        }
    }
}