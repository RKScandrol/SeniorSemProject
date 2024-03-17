using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{


    private int health;
    private int baseHealth;
    private int attack;
    private int baseAttack;
    private int defense;
    private int baseDefense;

    // Start is called before the first frame update
    void Start()
    {
        baseHealth = 100;
        health = 100;

        baseAttack = 15;
        attack = 15;

        baseDefense = 10;
        defense = 10;


        
        Debug.Log(this.debugStats());   //For TestingPurposes
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getHealth() {
        return health;
    }
    public void setHealth(int health) {
        this.health = health;
    }

    public int getBaseHealth() {
        return baseHealth;
    }
    public void setBaseHealth(int baseHealth) {
        this.baseHealth = baseHealth;
    }

    public int getAttack() {
        return attack;
    }
    public void setAttack(int attack) {
        this.attack = attack;
    }

    public int getBaseAttack() {
        return baseAttack;
    }
    public void setBaseAttack(int baseAttack) {
        this.baseAttack = baseAttack;
    }

    public int getDefense() {
        return defense;
    }
    public void setDefense(int defense) {
        this.defense = defense;
    }

    public int getBaseDefense() {
        return baseDefense;
    }
    public void setBaseDefense(int baseDefense) {
        this.baseDefense = baseDefense;
    }



    public void restoreBaseStats() {
        attack = baseAttack;
        defense = baseDefense;
    }
    public void restoreBaseAttack() {
        attack = baseAttack;
    }
    public void restoreBaseDefense() {
        defense = baseDefense;
    }

    /*
        Lowers Health of Enemy based off of opposing Attack
        DamageTaken is equal to the opposingAttack minus the defense
        If the calculated damage is less than or equal to 0, the damage is auto set to 1
        If the new health is less than or equal to 0, the enemy is destroyed
        Returns the amount of damage taken
    */
    public int takeDamage(int opposingAttack) {
        int damageTaken = opposingAttack - defense;
        if (damageTaken <= 0) {
            damageTaken = 1;
        }

        health -= damageTaken;

        if (health <= 0 ) {
            
        }

        return damageTaken;

    }

    /*
        Restores Enemy Health based on percent of current health
        Returns the amount of health Restored
    */
    public double restoreHealthByPercent(double restore) {
        double healthRestore = (double)health * restore;
        if (health + healthRestore > baseHealth) {
            healthRestore = baseHealth - health;
        }

        health += (int)Math.Floor(healthRestore);

        return healthRestore;
    }

    /*
        Decreases Attack by a percent of the current Attack
        If Attack minus the decrease is less than or equal to 0, Attack is set to 1
        Returns new Attack value
    */
    public int decreaseAttackByPercent(double percent) {
        int decrease = (int)Math.Floor(percent * (double)attack);

        if (attack - decrease <= 0) {
            attack = 1;
            return attack;
        }
        else {
            attack -= decrease;
            return attack;
        }
    }

    /*
        Increases Attack by a percent of the current Attack
        Does not matter if the Attack is increased past the Base
        Retruns the new Attack value
    */
    public int increaseAttackByPercent(double percent) {
        int increase = (int)Math.Floor(percent * (double)attack);

        attack += increase;
        return attack;
    }

    /*
        Decrease Defense by a percent of the current Defense
        If Defense minus the decrease is less than or equal to 0, Defense is set to 1
        Returns the new Defense value
    */
    public int decreaseDefenseByPercent(double percent) {
        int decrease = (int)Math.Floor(percent * (double)defense);

        if (defense - decrease <= 0) {
            defense = 1;
            return defense;
        }
        else {
            defense -= decrease;
            return defense;
        }
    }

    /*
        Increases Defense by a percent of the current Defense
        Does not matter if the Defense is increased past the Base
        Retruns the new Defense value
    */
    public int increaseDefenseByPercent(double percent) {
        int increase = (int)Math.Floor(percent * (double)defense);

        defense += increase;
        return defense;
    }




    //For Testing Purposes
    public string debugStats() {
        return "Base Health: " + baseHealth 
                + "\nHealth: " + health
                + "\nBase Attack: " + baseAttack
                + "\nAttack: " + attack
                + "\nBase Defense: " + baseDefense
                + "\nDefense: " + defense;
    }
}