using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{
    public int health;
    public int attack;
    public int defense;
    private int floorMod;
    [SerializeField]private int baseGoldDrop;
    
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    private int baseHealth, baseAttack, baseDefense;


    public XRayStats xray;
    public EnemyHealthbar enemyHealthbar;

    // Start is called before the first frame update
    void Start()
    {

        readStats();
        
        //Applies stat modifiers based on current floor
        floorMod = GameObject.FindGameObjectWithTag("FloorManager").GetComponent<FloorManager>().currentFloor;
        attack += floorMod + 2;
        defense += floorMod + 2;
        health += floorMod * 2;
        //baseGoldDrop += floorMod + 2;

        
        xray.initializeXRayStats();

        
        // Debug.Log(this.debugStats());   //For TestingPurposes

        
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

        enemyHealthbar.UpdateHealth((float)health / (float)baseHealth);
    }

    public int getBaseHealth() {
        return baseHealth;
    }
    public void setBaseHealth(int baseHealth) {
        this.baseHealth = baseHealth;

        enemyHealthbar.UpdateHealth((float)health / (float)baseHealth);
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

        xray.setText();
    }
    public void restoreBaseAttack() {
        attack = baseAttack;

        xray.setText();
    }
    public void restoreBaseDefense() {
        defense = baseDefense;

        xray.setText();
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
            this.gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().enabled = false;
            CircleCollider2D[] collider2Ds = this.gameObject.GetComponents<CircleCollider2D>();
            foreach (CircleCollider2D collider2D in collider2Ds) {
                collider2D.enabled = false;
            }
            Animator animator = this.gameObject.transform.Find("EnemyDeath").GetComponent<Animator>();
            animator.Play("EnemyDeathAnimation");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>().increaseGold(baseGoldDrop);
        }

        enemyHealthbar.UpdateHealth((float)health / (float)baseHealth);

        // Debug.Log("EnemyDamageTaken: " + damageTaken + " opposingAttck: " + opposingAttack);

        return damageTaken;

    }

    /*
        Restores Enemy Health based on percent of Base Health
        Returns the amount of health Restored
    */
    public double restoreHealthByPercent(double restore) {
        double healthRestore = (double)health * restore;
        if (health + healthRestore > baseHealth) {
            healthRestore = baseHealth - health;
        }

        health += (int)Math.Ceiling(healthRestore);

        enemyHealthbar.UpdateHealth((float)health / (float)baseHealth);

        return healthRestore;
    }

    /*
        Decreases Attack by a percent of the current Attack
        If Attack minus the decrease is less than or equal to 0, Attack is set to 1
        Returns new Attack value
    */
    public int decreaseAttackByPercent(double percent) {
        int decrease = (int)Math.Ceiling(percent * (double)attack);

        if (attack - decrease <= 0) {
            attack = 1;
            xray.setText();
            return attack;
        }
        else {
            attack -= decrease;
            xray.setText();
            return attack;
        }
    }

    /*
        Increases Attack by a percent of the current Attack
        Does not matter if the Attack is increased past the Base
        Retruns the new Attack value
    */
    public int increaseAttackByPercent(double percent) {
        int increase = (int)Math.Ceiling(percent * (double)attack);

        attack += increase;
        xray.setText();
        return attack;
    }

    /*
        Decrease Defense by a percent of the current Defense
        If Defense minus the decrease is less than or equal to 0, Defense is set to 1
        Returns the new Defense value
    */
    public int decreaseDefenseByPercent(double percent) {
        int decrease = (int)Math.Ceiling(percent * (double)defense);

        if (defense - decrease <= 0) {
            defense = 1;
            xray.setText();
            return defense;
        }
        else {
            defense -= decrease;
            xray.setText();
            return defense;
        }
    }

    /*
        Increases Defense by a percent of the current Defense
        Does not matter if the Defense is increased past the Base
        Retruns the new Defense value
    */
    public int increaseDefenseByPercent(double percent) {
        int increase = (int)Math.Ceiling(percent * (double)defense);

        defense += increase;
        xray.setText();
        return defense;
    }



    public void readStats() {

        string[] lines = File.ReadAllLines(Application.streamingAssetsPath + "/Enemy/StandardEnemyStats.json");
        string jsonStr = "";

        foreach (string line in lines) {
            jsonStr += line;
        }
        
        EnemyBaseStats enemyBaseStats = JsonUtility.FromJson<EnemyBaseStats>(jsonStr);
        setStats(enemyBaseStats);
    }

    public void setStats(EnemyBaseStats enemyBaseStats) {

        /*
            NOTICE:  This function should modify base stats based on the level number
        */

        baseHealth = enemyBaseStats.baseHealth;
        baseAttack = enemyBaseStats.baseAttack;
        baseDefense = enemyBaseStats.baseDefense;

        //Base Stat Modifiers goes here

        health = baseHealth;
        attack = baseAttack;
        defense = baseDefense;

        baseGoldDrop = enemyBaseStats.baseGold;

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



public struct EnemyBaseStats {

    public int baseHealth;
    public int baseAttack;
    public int baseDefense;
    public int baseGold;

}
