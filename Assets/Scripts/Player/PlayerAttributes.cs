using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

    public struct PlayerBaseStats{
        public int health;
        public int defense;
        public int attack;
        public int movespeed;
    }
public class PlayerAttributes : MonoBehaviour
{


    public int maxHealth;
    public int currentHealth;
    public int defense;
    public int attack;
    public int moveSpeed;

    public HealthBar hb;

    // Start is called before the first frame update
    void Start()
    {

        String path = Application.dataPath + "/Scripts/Player/PlayerStats.json";

        PlayerBaseStats stats = getPermStatus();

        //Set all player attributes to their base values
        attack = stats.attack;
        maxHealth = stats.health;
        moveSpeed = stats.movespeed;
        defense = stats.defense;
        //Set all player attributes to their proper values
        //TODO: set these using the permanent counters in Scandrol_4
        // modifyDamage(/*TODO: FIll these in*/);
        // modifyMaxHealth();
        // modifyMoveSpeed();
        // modifyDefense();
        hb.SetMaxHealth(maxHealth);
        setCurrentHealth(maxHealth);
    }


    // Update is called once per frame
    void Update()
    {
        //Tests, not to be live code
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     modifyCurrentHealth(-20);
        // }
    }




    PlayerBaseStats getPermStatus()
    {
        String path = Application.dataPath + "/Scripts/Player/PlayerStats.json";

        PlayerBaseStats stats = JsonUtility.FromJson<PlayerBaseStats>(path);

        return stats;
    }
  

    //Modifies the movement speed of the character by multiplying it by some float value.
    void modifyMoveSpeed(int mod)
    {
        moveSpeed *= mod;
    }

    //Modifies the base damage of the character by multiplying it by some float value.
    void modifyDamage(int mod)
    {
        attack *= mod;
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
    public void setCurrentHealth(int val)
    {
        if (val <= 0) {
            Debug.Log("Player Health cannot be Value: " + val);
        }
        else if(val>maxHealth)
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
