using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class TimeWeakness : Item
{

    [SerializeField]double effectTime;      //In Minutes
    DateTime activationTime;
    [SerializeField]double defenseDropPercentage;

    public TimeWeakness(int itemID, string name, string description, int weight, 
    double effectTime, double defenseDropPercentage) : 
    base(itemID, name, description, weight) {

        this.effectTime = effectTime;
        this.defenseDropPercentage = defenseDropPercentage;
    }

    public TimeWeakness(int itemID, string name, string description, int weight, int minWeight, int maxWeight,
    double effectTime, DateTime activationTime, double defenseDropPercentage) : 
    base(itemID, name, description, weight, minWeight, maxWeight) {

        this.effectTime = effectTime;
        this.activationTime = activationTime;
        this.defenseDropPercentage = defenseDropPercentage;
        
    }


    /*
        Gets all GameObjects with Enemy Tag
        Restores their Defense stat to their Base stat
        Removes Item from Item List in Clock
    */
    public override void activateItem() 
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            EnemyAttributes enemyAttributes = enemy.GetComponent<EnemyAttributes>();
            enemyAttributes.restoreBaseDefense();
        }

        ItemClock itemClock = GameObject.Find("Clock").GetComponent<ItemClock>();
        itemClock.addItemToRemove(this);
    }

    public override DateTime getActivationTime()
    {
        return activationTime;
    }

    public override string getDescription()
    {
        return description;
    }

    public override string getIconPath()
    {
        return "";
    }

    /*
        Increments Activation Time by Effect Time
        Adds Item to List in Clock
        Gets all GameObjects with Enemy Tag
        Decreases their Defense stats by Defense Drop Percent
    */
    public override void initializeItem()
    {
        activationTime = DateTime.Now.AddMinutes(effectTime);

        ItemClock itemClock = GameObject.Find("Clock").GetComponent<ItemClock>();
        itemClock.addItem(this);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            EnemyAttributes enemyAttributes = enemy.GetComponent<EnemyAttributes>();
            enemyAttributes.decreaseDefenseByPercent(defenseDropPercentage);
        }
    }

    /*
        Gets all GameObjects with Enemy Tag
        Decreases their Defense stats again by Defense Drop Percent
        Does Not extend time limit
    */
    public override void intensify()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            EnemyAttributes enemyAttributes = enemy.GetComponent<EnemyAttributes>();
            enemyAttributes.decreaseDefenseByPercent(defenseDropPercentage);
        }

    }

}
