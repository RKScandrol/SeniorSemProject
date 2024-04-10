using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]public class OHKO : Item
{

    private DateTime activationTime;
    [SerializeField]private int timeIncrement;              //In seconds
    [SerializeField]private int regenDuration;              //Decrements with each regen, How many times the Enemies Health will Regenerate
    [SerializeField]private double regenPercent;  

    public OHKO(int itemID, string name, string description, int weight, 
    int timeIncrement, int regenDuration, double regenPercent) : 
    base(itemID, name, description, weight)
    {
        this.timeIncrement = timeIncrement;
        this.regenDuration = regenDuration;
        this.regenPercent = regenPercent;
    }

    public OHKO(int itemID, string name, string description, int weight, int minWeight, int maxWeight,
    DateTime activationTime, int timeIncrement, int regenDuration, double regenPercent) : 
    base(itemID, name, description, weight, minWeight, maxWeight)
    {
        this.activationTime = activationTime;
        this.timeIncrement = timeIncrement;
        this.regenDuration = regenDuration;
        this.regenPercent = regenPercent;
    }

    

    public override DateTime getActivationTime()
    {
        return activationTime;
    }

    public override string getDescription()
    {
        return description + 
            "Regen Time: " + (regenDuration * timeIncrement) + 
            " seconds\nRegen Percent: " + regenPercent*100 + "%";
    }

    public override string getIconPath()
    {
        return "";
    }



    public override void initializeItem()
    {  
        //Gets all GameObjects with Enemy Tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Sets the Health of each Enemy to 1
        foreach (GameObject enemy in enemies) {
            EnemyAttributes enemyAttributes = enemy.GetComponent<EnemyAttributes>();
            enemyAttributes.setHealth(1);

            //For testing
            // Debug.Log(enemyAttributes.debugStats());
        }
        //Sets the Player's Health to 1
        PlayerAttributes playerAttributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();
        playerAttributes.setCurrentHealth(1);
        //Adds Item to Clock
        ItemClock itemClock = GameObject.Find("Clock").GetComponent<ItemClock>();
        itemClock.addItem(this);
        //Set and Increment Activation Time
        activationTime = DateTime.Now.AddSeconds(timeIncrement);


        
    }



    public override void activateItem()
    {
        //Gets all GameObjects with Enemy Tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Regenerates Enemy Health by Percent
        foreach (GameObject enemy in enemies) {
            EnemyAttributes enemyAttributes = enemy.GetComponent<EnemyAttributes>();
            enemyAttributes.restoreHealthByPercent(regenPercent);

            //For testing
            // Debug.Log(enemyAttributes.debugStats());
        }
        //Decrement the duration
        regenDuration--;
        //Increase the Activation Time
        activationTime = activationTime.AddSeconds(timeIncrement);
        //If the end of the duration is reached, remove the item from the Clock List
        if (regenDuration <= 0) {
            ItemClock itemClock = GameObject.Find("Clock").GetComponent<ItemClock>();
            itemClock.addItemToRemove(this);
        }
    }

    /*
        Resets the Health of All Enemies back to 1
        Increased Regen Percent by 25%
        Does NOT effect the Time Increment or Regen Duration
    */
    public override void intensify()
    {
        //Gets all GameObjects with Enemy Tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Resets the Health of each Enemy to 1
        foreach (GameObject enemy in enemies) {
            EnemyAttributes enemyAttributes = enemy.GetComponent<EnemyAttributes>();
            enemyAttributes.setHealth(1);
        }
        //Increase Regen Percent
        regenPercent += 0.25;
    }
}
