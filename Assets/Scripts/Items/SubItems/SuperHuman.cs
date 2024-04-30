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
    private float actualMoveSpeed;
    private int actualAttack;
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
    float moveSpeedPercentBoost, float actualMoveSpeed, int actualAttack) : 
    base(itemID, name, description, weight, minWeight, maxWeight)
    {
        this.activationTime = activationTime;
        this.effectTime = effectTime;
        this.attackPercentBoost = attackPercentBoost;
        this.moveSpeedPercentBoost = moveSpeedPercentBoost;
        this.actualMoveSpeed = actualMoveSpeed;
        this.actualAttack = actualAttack;
    }

    

    public override DateTime getActivationTime()
    {
        return activationTime;
    }

    public override string getDescription()
    {
        return description + 
            "Attack Boost: " + (attackPercentBoost*100) + 
            "%\nMove Speed Boost: " + (moveSpeedPercentBoost*100) + 
            "%\nEffect Time: " + effectTime + " minutes";
    }

    public override string getIconPath()
    {
        return "/ItemIcons/SuperHuman.png";
    }



    public void boostActualAttack(double percent) {
        actualAttack += (int)Math.Ceiling((double)actualAttack * percent);

        Debug.Log("Actual Attack boosted \n" + 
        "Percent: " + percent + "\nNew Attack: " + actualAttack);
    }
    public void increaseActualAttackByPoints(int points) {
        actualAttack += points;
    }
    public int decreaseActualAttackByPoints(int points) {
        int attackPointsTaken = 0;
        if (actualAttack - points < 0) {
            attackPointsTaken = actualAttack - 1;
            actualAttack = 1;
        }
        else {
            attackPointsTaken = points;
            actualAttack -= points;
        }
        return attackPointsTaken;
    }

    public float getActualMoveSpeed() {
        return actualMoveSpeed;
    }



    public override void initializeItem()
    {
        //Get the Clock
        ItemClock itemClock = GameObject.Find("Clock").GetComponent<ItemClock>();
        //Get any SuperHuman Item that exists, if any
        SuperHuman sh = itemClock.getItemOfType<SuperHuman>();
        //If a SuperHuman Item does not yet exist
        if (sh == default) {
            //Get the Player GameObject
            player_char = GameObject.FindGameObjectWithTag("Player");
            //Get Player Attributes Script
            PlayerAttributes playerAttributes = player_char.GetComponent<PlayerAttributes>();
            //Get Player Controller Script
            Player playerController = player_char.GetComponent<Player>();
            //Save the Player's Actual Attack
            actualAttack = playerAttributes.attack;
            //Boost the Player's Attack
            playerAttributes.increaseAttackByPercent(attackPercentBoost);
            //Save the Player's Actual Move Speed
            actualMoveSpeed = playerController.moveSpeed;
            //Boost the Player's Move Speed
            playerController.boostMoveSpeedByPercent(moveSpeedPercentBoost);

            //Set Activaion Time
            activationTime = DateTime.Now.AddMinutes(effectTime);
            //Add Item to Clock
            itemClock.addItem(this);
            //Get any HeavyWeight ITem that exists, if any
            HeavyWeight hw = itemClock.getItemOfType<HeavyWeight>();
            //If a HeavyWeight Item does exist
            if (hw != default) {
                //Set the Player's actual MoveSpeed to the Move Speed from the HeavyWeight Item
                actualMoveSpeed = hw.getActualMoveSpeed();
            }


            Debug.Log("SuperHuman Initialized and added to clock");
        }
        //If a SuperHuman Item Already Exists
        else {
            //Intensify the Existing SuperHuman Item
            sh.intensify();

            Debug.Log("SuperHuman Inialized but not added to Clock");
        }

    }

    public override void activateItem()
    {
        //Get Player Attributes Script
        PlayerAttributes playerAttributes = player_char.GetComponent<PlayerAttributes>();
        //Get Player Controller Script
        Player playerController = player_char.GetComponent<Player>();
        //Reset Player's Attack
        playerAttributes.attack = actualAttack;
        //Reset Player's Move Speed
        playerController.moveSpeed = actualMoveSpeed;

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
