using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class AttackDefenseTradeOff : Item
{

    /*
        Trade some Attack points for Defense
    */

    
    [SerializeField]private int pointsToTrade;

    public AttackDefenseTradeOff(int itemID, string name, string description, int weight, int minWeight, int maxWeight, 
    int pointsToTrade) :
    base(itemID, name, description, weight) {
        
        this.pointsToTrade = pointsToTrade;

    }

    public AttackDefenseTradeOff(int itemID, string name, string description, int weight, 
    int pointsToTrade) :
    base(itemID, name, description, weight) {

        this.pointsToTrade = pointsToTrade;

    }



    public override string getIconPath() {
        return "/ItemIcons/TradeOffAttackForDefenseIcon.png";
    }

    public override string getDescription() {
        return description + "\nTrade up to " + pointsToTrade + " points as available.";
    }


    public int getpointsToTrade() {
        return pointsToTrade;
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
        //Number of points taken from Attack and to be applied to Defense
        int pointsChange;
        //If there is an Active SuperHuman Item
        if (sh != default) {
            //Decrease the actual attack by points to trade, save the number actually taken
            pointsChange = sh.decreaseActualAttackByPoints(pointsToTrade);
            //Decrease the attack in PlayerAttributes
            playerAttributes.decreaseAttackByPoints(pointsChange);
        }
        //If there is no active SuperHuman Item
        else {
            //Get the number of points from the Attack attribute
            pointsChange = playerAttributes.decreaseAttackByPoints(pointsToTrade);
        }


        //Increase the Defense attribute
        playerAttributes.increaseDefenseByPoints(pointsChange);
        //If there is an active HeavyWeight Item
        if (hw != default) {
            //Increase the Actual Defense stored in the HeavyWeight Item
            hw.increaseActualDefenseByPoints(pointsChange);
        }


        Debug.Log("TradeOff initialized\n" + pointsChange + " points taken from Attack and applied to Defense");
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