using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class SuperHuman : Item
{

    private DateTime activationTime;
    [SerializeField]private double effectTime;      //In Minutes
    [SerializeField]private double attackPercentBoost;
    [SerializeField]private float moveSpeedPercentBoost;
    private float previousMoveSpeed;
    private int previousAttack;
    private GameObject player_char;

    public SuperHuman(int itemID, string name, string description, int weight, 
    double effectTime, double attackPercentBoost, float moveSpeedPercentBoost) : 
    base(itemID, name, description, weight)
    {
        this.effectTime = effectTime;
        this.attackPercentBoost = attackPercentBoost;
        this.moveSpeedPercentBoost = moveSpeedPercentBoost;
    }

    public SuperHuman(int itemID, string name, string description, int weight, int minWeight, int maxWeight, 
    DateTime activationTime, double effectTime, double attackPercentBoost, 
    float moveSpeedPercentBoost, float previousMoveSpeed, int previousAttack) : 
    base(itemID, name, description, weight, minWeight, maxWeight)
    {
        this.activationTime = activationTime;
        this.effectTime = effectTime;
        this.attackPercentBoost = attackPercentBoost;
        this.moveSpeedPercentBoost = moveSpeedPercentBoost;
        this.previousMoveSpeed = previousMoveSpeed;
        this.previousAttack = previousAttack;
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



    public void boostPreviousAttack(double percent) {
        previousAttack += (int)Math.Ceiling((double)previousAttack * percent);

        Debug.Log("Actual Attack boosted \n" + 
        "Percent: " + percent + "\nNew Attack: " + previousAttack);
    }



    public override void initializeItem()
    {
        //Get the Player GameObject
        player_char = GameObject.FindGameObjectWithTag("Player");
        //Get Player Attributes Script
        PlayerAttributes playerAttributes = player_char.GetComponent<PlayerAttributes>();
        //Get Player Controller Script
        Player playerController = player_char.GetComponent<Player>();
        //Save the Player's Attack
        previousAttack = playerAttributes.attack;
        //Boost the Player's Attack
        playerAttributes.increaseAttackByPercent(attackPercentBoost);
        //Save the Player's Move Speed
        previousMoveSpeed = playerController.moveSpeed;
        //Boost the Player's Move Speed
        playerController.boostMoveSpeedByPercent(moveSpeedPercentBoost);

        //Set Activaion Time
        activationTime = DateTime.Now.AddMinutes(effectTime);
        //Add Item to Clock
        ItemClock itemClock = GameObject.Find("Clock").GetComponent<ItemClock>();
        itemClock.addItem(this);


        Debug.Log("SuperHuman Initialized");

    }

    public override void activateItem()
    {
        //Get Player Attributes Script
        PlayerAttributes playerAttributes = player_char.GetComponent<PlayerAttributes>();
        //Get Player Controller Script
        Player playerController = player_char.GetComponent<Player>();
        //Reset Player's Attack
        playerAttributes.attack = previousAttack;
        //Reset Player's Move Speed
        playerController.moveSpeed = previousMoveSpeed;

        ItemClock itemClock = GameObject.Find("Clock").GetComponent<ItemClock>();
        itemClock.addItemToRemove(this);


        Debug.Log("SuperHuman Deactivated");

    }

    public override void intensify()
    {
        //Get Player Attributes Script
        PlayerAttributes playerAttributes = player_char.GetComponent<PlayerAttributes>();
        //Get Player Controller Script
        Player playerController = player_char.GetComponent<Player>();
        //Boost the Player's Attack
        playerAttributes.increaseAttackByPercent(attackPercentBoost);
        //Boost the PLayer's Move Speed
        playerController.boostMoveSpeedByPercent(moveSpeedPercentBoost);


        Debug.Log("SuperHuman Intensified");

    }

}
