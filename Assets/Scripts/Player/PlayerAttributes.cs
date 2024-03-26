using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public float moveSpeed = 20.0f;
    public float maxHealth = 100.0f;
    public float currentHealth;
    public float damage = 10.0f;

    public HealthBar hb;

    // Start is called before the first frame update
    void Start()
    {
        //Set all player attributes to their proper values
        modifyDamage(getPermStatus("damage"));
        modifyMaxHealth(getPermStatus("maxHealth"));
        modifyMoveSpeed(getPermStatus("moveSpeed"));
        hb.SetMaxHealth(maxHealth);
        setCurrentHealth(maxHealth);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            modifyCurrentHealth(-20);
        }
    }




    //Gets a value from Json as a float based on a given name of that attribute.
    float getPermStatus(string statName)
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
        hb.SetHealth(currentHealth);
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
