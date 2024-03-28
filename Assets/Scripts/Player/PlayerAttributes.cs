using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public int moveSpeed;
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public int defense;

    public HealthBar hb;

    // Start is called before the first frame update
    void Start()
    {
        //Set all player attributes to their base values
        damage = getBaseStatus("damage");
        maxHealth = getBaseStatus("maxHealth");
        moveSpeed = getBaseStatus("moveSpeed");
        defense = getBaseStatus("defense");
        //Set all player attributes to their proper values
        modifyDamage(getPermStatus("damage"));
        modifyMaxHealth(getPermStatus("maxHealth"));
        modifyMoveSpeed(getPermStatus("moveSpeed"));
        modifyDefense(getPermStatus("defense"));
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
    int getPermStatus(string statName)
    {
        //TODO: get JSON as float;

        return 1;
    }

    int getBaseStatus(string statName)
    {
        //TODO: get JSON as float;

        return 1;
    }

    //Modifies the movement speed of the character by multiplying it by some float value.
    void modifyMoveSpeed(int mod)
    {
        moveSpeed *= mod;
    }

    //Modifies the base damage of the character by multiplying it by some float value.
    void modifyDamage(int mod)
    {
        damage *= mod;
    }


    //Modifies the base defense of the character by multiplying it by some float value.
    void modifyDefense(int mod)
    {
        defense *= mod;
    }

    //Modifies the max health of the character my multiplying it by some float value.
    void modifyMaxHealth(int mod)
    {
        maxHealth *= mod;
    }

    //Modifies the current health value by adding a certain float to it.
    void modifyCurrentHealth(int mod)
    {
        currentHealth += mod;
        hb.SetHealth(currentHealth);
    }

    //Sets the current health to a desired value (used mainly for initialization of the character.)
    void setCurrentHealth(int val)
    {
        if(val>maxHealth)
        {
            currentHealth = maxHealth;
        }else
        {
            currentHealth = val;
        }
    }

    void die()
    {
        setCurrentHealth(0);
    }

    void takeDamage(int val)
    {
        modifyCurrentHealth(-val);
    }
}
