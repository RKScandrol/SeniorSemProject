using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class LifeSteal : Item
{


    [SerializeField]private double percentSteal;
    [SerializeField]private double effectTime;      //In Minutes
    private DateTime activationTime;


    public LifeSteal(int itemID, string name, string description, int weight, 
    double percentSteal, double effectTime) : 
    base(itemID, name, description, weight)
    {
        this.percentSteal = percentSteal;
        this.effectTime = effectTime;
    }

    public LifeSteal(int itemID, string name, string description, int weight, int minWeight, int maxWeight, 
    double percentSteal, double effectTime, DateTime activationTime) : 
    base(itemID, name, description, weight, minWeight, maxWeight)
    {
        this.percentSteal = percentSteal;
        this.effectTime = effectTime;
        this.activationTime = activationTime;
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
        return "Assets/Graphics/ItemIcons/LifeStealIcon.png";
    }


    public int giveLifeToPlayer(int damageTaken) {
        //Calculate number of points to give to Player's CurrentHealth
        int healthPointsToRestore = (int)Math.Ceiling((double)damageTaken * percentSteal);
        //Get PlayerAttributes component
        PlayerAttributes playerAttributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();
        //Increase Player's CurrentHealth
        playerAttributes.increaseCurrentHealthByPoints(healthPointsToRestore);

        // Debug.Log("damageTaken: " + damageTaken + " HealthPointsToRestore: " + healthPointsToRestore);

        //Return Health Points restored
        return healthPointsToRestore;
    }


    public override void initializeItem()
    {
        //Get ItemClock
        ItemClock itemClock = GameObject.Find("Clock").GetComponent<ItemClock>();
        //Try to add LifeSteal to Clock
        bool successfullyAdded = itemClock.addItem(this);
        //If LifeSteal was added to Clock
        if (successfullyAdded) {
            //Increment ActivationTime
            activationTime = DateTime.Now.AddMinutes(effectTime);
            //Get PlayerCombat Component from Player
            PlayerCombat playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
            //Add LifeSteal to playerCombat
            playerCombat.addLifeSteal(this);
            
        }

        Debug.Log("LifeSteal Initialized");
    }

    public override void activateItem()
    {
        //Get ItemClock
        ItemClock itemClock = GameObject.Find("Clock").GetComponent<ItemClock>();
        //Set LifeSteal to be removed from Clock
        itemClock.addItemToRemove(this);

        //Increment ActivationTime
        activationTime = activationTime.AddMinutes(effectTime);

        //Get PlayerCombat Component from Player
        PlayerCombat playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        //Remove LifeSteal from playerCombat
        playerCombat.removeLifeSteal();
    }

    public override void intensify()
    {
        //Increase Activation Time
        activationTime = activationTime.AddMinutes(effectTime/2);
        //Increase PercentSteal
        percentSteal += percentSteal * 0.5;
    }
}
