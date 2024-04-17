using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class AttackDefenseTradeOff : Item
{

    
    [SerializeField]private double percentBoost;

    public AttackDefenseTradeOff(int itemID, string name, string description, int weight, int minWeight, int maxWeight, 
    double percentBoost) :
    base(itemID, name, description, weight) {
        
        this.percentBoost = percentBoost;

    }

    public AttackDefenseTradeOff(int itemID, string name, string description, int weight, 
    double percentBoost) :
    base(itemID, name, description, weight) {

        this.percentBoost = percentBoost;

    }



    public override string getIconPath() {
        return "";
    }

    public override string getDescription() {
        return description;
    }


    public double getPercentBoost() {
        return percentBoost;
    }



    public override void initializeItem() {
        //Get the PLayer Object
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //Get the Player Attributes
        PlayerAttributes playerAttributes = player.GetComponent<PlayerAttributes>();
        
        //Get the Item Clock
        ItemClock itemClock = GameObject.Find("Clock").GetComponent<ItemClock>();
        //Get any active HeavyWeight Item
        HeavyWeight hw = itemClock.getItemOfType<HeavyWeight>();
        //Get any active SuperHuman Item
        SuperHuman sh = itemClock.getItemOfType<SuperHuman>();
        //Number of points taken from Defense and to be applied to Attack
        int pointsChange;
        //If there is an Active HeavyWeight Item
        if (hw != default) {
            //Get the number of points from the Actual Defense stored in HeavyWeight
            pointsChange = hw.decreaseActualDefenseByPercent(percentBoost);
            //Change the temporary Defense
            playerAttributes.decreaseDefenseByPoints(pointsChange);
        }
        //If there is no active HeavyWeight Item
        else {
            //Get the number of points from the Defense attribute
            pointsChange = playerAttributes.decreaseDefenseByPercent(percentBoost);
        }


        //Increase the Attack attribute
        playerAttributes.increaseAttackByPoints(pointsChange);
        //If there is an active SuperHuman Item
        if (sh != default) {
            //Increase the Actual Attack stroed in the SuperHuman Item
            sh.increaseActualAttackByPoints(pointsChange);
        }


        Debug.Log(pointsChange + " points taken from Defense and applied to Attack");
    }



    //Should not be used
    public override DateTime getActivationTime() {
        throw new NotImplementedException();
    }
    //Should not be used
    public override void activateItem() {
        throw new NotImplementedException();
    }
    //Should not be used
    public override void intensify() {
        throw new NotImplementedException();
    }



}