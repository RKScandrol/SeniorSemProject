using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class DefenseAttackTradeOff : Item
{

    /*
        Trade some Defense Points for Attack Points
    */


    [SerializeField]private int pointsToTrade;


    public DefenseAttackTradeOff(int itemID, string name, string description, int weight, 
    int pointsToTrade) : 
    base(itemID, name, description, weight)
    {
        this.pointsToTrade = pointsToTrade;
    }

    public DefenseAttackTradeOff(int itemID, string name, string description, int weight, int minWeight, int maxWeight, 
    int pointsToTrade) : 
    base(itemID, name, description, weight, minWeight, maxWeight)
    {
        this.pointsToTrade = pointsToTrade;
    }

    

    public override string getDescription()
    {
        return description + "\nTrade up to " + pointsToTrade + " points as available.";
    }

    public override string getIconPath()
    {
        return "Assets/Graphics/ItemIcons/TradeOffDefenseForAttackIcon.png";
    }

    public override void initializeItem()
    {
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
            //Decrease the Actual Defense by points to trade, save the number actually taken
            pointsChange = hw.decreaseActualDefenseByPoints(pointsToTrade);
            //Decrease the Defense in PlayerAttributes
            playerAttributes.decreaseDefenseByPoints(pointsChange);
        }
        //If there is no active HeavyWeight Item
        else {
            //Get the number of points from the Defense attribute
            pointsChange = playerAttributes.decreaseDefenseByPoints(pointsToTrade);
        }


        //Increase the Attack attribute
        playerAttributes.increaseAttackByPoints(pointsChange);
        //If there is an active SuperHuman Item
        if (sh != default) {
            //Increase the Actual Attack stored in the SuperHuman Item
            sh.increaseActualAttackByPoints(pointsChange);
        }


        Debug.Log("TradeOff initialized\n" + pointsChange + " points taken from Defense and applied to Attack");
    }



    public override void activateItem()
    {
        throw new NotImplementedException();
    }

    public override DateTime getActivationTime()
    {
        throw new NotImplementedException();
    }

    public override void intensify()
    {
        throw new NotImplementedException();
    }
}
