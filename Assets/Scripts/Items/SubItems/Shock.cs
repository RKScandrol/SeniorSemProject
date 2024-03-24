using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class Shock : Item
{

    [SerializeField]private double timeIncrement;  //In Minutes
    private DateTime activationTime;
    [SerializeField]private int damage;



    public Shock(int itemID, string name, string description, int weight, int minWeight, int maxWeight, 
    double timeIncrement, DateTime activationTime, int damage) :
    base(itemID, name, description, weight) {
        
        // this.itemType = ItemType.Passive;
        this.timeIncrement = timeIncrement;
        this.activationTime = activationTime;
        this.damage = damage;
    
    }

    public Shock(int itemID, string name, string description, int weight, 
    double timeIncrement, int damage) :
    base(itemID, name, description, weight) {

        // this.itemType = ItemType.Passive;
        this.timeIncrement = timeIncrement;
        this.damage = damage;

        Debug.Log("Shock " + itemID +  
                    "\nTime Increment: " + timeIncrement + 
                    "\nDamage: " + damage);

    }


    public override string getIconPath() {
        return "Assets/Graphics/ItemIcons/ShockIcon.png";
    }

    public override string getDescription() {
        return description + "\nAttack Power: " + damage + "\nWait Time: " + timeIncrement + " minutes";
    }

    public double getTimeIncrement() {
        return timeIncrement;
    }

    public override DateTime getActivationTime() {
        return activationTime;
    }
    public void setActivationTime(DateTime activationTime) {
        this.activationTime = activationTime;
    }
    public void incrementActivationTime() {
        activationTime = activationTime.AddMinutes(timeIncrement);
    }

    /*
        Sets the time for the next Activation to the current time, plus the time increment
        Adds the Shock to the Clock item list
    */
    public override void initializeItem() {
        //Sets Activation Time
        setActivationTime(DateTime.Now.AddMinutes(timeIncrement));
        Debug.Log("Shock " + itemID + " initialized");
        //Adds Shock to Clock
        GameObject gameClock = GameObject.Find("Clock");
        ItemClock itemClock = gameClock.GetComponent<ItemClock>();
        itemClock.addItem(this);
    }

    /*
        Gets All of the GameObjects with the Enemy Tag,
        Checks the distance between each Enemy and the Player for the shortest Distance,
        Shocks the enemy with the shortest distance, dealing damage,
        Incrementsa time until next Activation
    */
    public override void activateItem() {
        //Increment Time
        incrementActivationTime();
        Debug.Log("Shock Activated");

        //List of Enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Player Posistion
        Vector2 guyPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        //Assume the 1st enemy is the closest
        int closestEnemyIdx = 0;
        float distance = Vector2.Distance(guyPos, enemies[0].GetComponent<Transform>().position);
        //Loop through all other enemies, checking for a closer one
        for (int i = 1 ; i < enemies.Length ; i++) {
            float checkDist = Vector2.Distance(guyPos, enemies[i].GetComponent<Transform>().position);

            if (checkDist < distance) {
                distance = checkDist;
                closestEnemyIdx = i;
            }
        }

        //Closest Enemy
        GameObject closestEnemy = enemies[closestEnemyIdx];
        //Play Shock animation for Enemy
        SpriteRenderer spriteRenderer = closestEnemy.transform.Find("Shock").GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        Animator animator = closestEnemy.transform.Find("Shock").GetComponent<Animator>();
        animator.Play("ShockAnimation");
        
        
        //Deal damage to the Enemy
        EnemyAttributes enemyAttributes = closestEnemy.GetComponent<EnemyAttributes>();
        enemyAttributes.takeDamage(damage);
        Debug.Log(closestEnemy.name + "\n" + enemyAttributes.debugStats());
        

    }

    /*
        Increases stats of Shock if the player choses it again from the Chest
        Decreases Time Increment by 30 seconds as long as it is currenlty 1.5 minute or longer,
        If the Time Increment is between 1 minute and 1.5 minutes, the Time Increment is set to 1 minute
        Increases Damage by 5 points

        NOTICE: Want to have the Damage increase scale based on the amount of Shocks picked, 
                instead of a static increase,
                or based on the shock that was picked, but not just adding the power
    */
    public override void intensify() {

        if (timeIncrement >= 1.5) {
            timeIncrement -= 0.5;
        }
        else if (timeIncrement >= 1.0) {
            timeIncrement = 1.0;
        }

        damage += 5;
        Debug.Log("Shock " + itemID + " intensified" + 
                    "\nTime Increment: " + timeIncrement + 
                    "\nDamage: " + damage);

    }




}
