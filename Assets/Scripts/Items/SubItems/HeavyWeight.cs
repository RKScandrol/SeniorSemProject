using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class HeavyWeight : Item
{

    /*
        This Item will temporarily will boost the player's defense stat at the cost of decreasing the player's move speed
        It will store the player's actual Defense and Move Speed so they may be reset later
        It will also provide a function to boost the Player's actual defense incase the Player obtains another item that will do such 
    */

    private DateTime activationTime;
    [SerializeField]private double effectTime;      //In Minutes
    [SerializeField]private double defensePercentBoost;
    [SerializeField]private float moveSpeedPercentDrop;
    private int actualDefense;
    private float actualMoveSpeed;
    private GameObject player;


    public HeavyWeight(int itemID, string name, string description, int weight, 
    double effectTime, double defensePercentBoost, float moveSpeedPercentDrop) : 
    base(itemID, name, description, weight)
    {
        this.effectTime = effectTime;
        this.defensePercentBoost = defensePercentBoost;
        this.moveSpeedPercentDrop = moveSpeedPercentDrop;
    }

    public HeavyWeight(int itemID, string name, string description, int weight, int minWeight, int maxWeight, 
    DateTime activationTime, double effectTime, double defensePercentBoost, float moveSpeedPercentDrop,
    int actualDefense, float actualMoveSpeed) : 
    base(itemID, name, description, weight, minWeight, maxWeight)
    {
        this.activationTime = activationTime;
        this.effectTime = effectTime;
        this.defensePercentBoost = defensePercentBoost;
        this.moveSpeedPercentDrop = moveSpeedPercentDrop;
        this.actualDefense = actualDefense;
        this.actualMoveSpeed = actualMoveSpeed;
    }

    

    public override DateTime getActivationTime()
    {
        return activationTime;
    }

    public override string getDescription()
    {
        return description + 
            "\nDefense Increase: " + (defensePercentBoost*100) + 
            "%\nMove Speed Drop: " + (moveSpeedPercentDrop*100) + 
            "%\nEffect Time: " + effectTime + " minutes";
    }

    public override string getIconPath()
    {
        return "Assets/Graphics/ItemIcons/HeavyWeight.png";
    }


    public void setActualDefense(int d) {
        actualDefense = d;
    }
    public int getActualDefense() {
        return actualDefense;
    }
    public void boostActualDefense(double percent) {
        int increase = (int)Math.Ceiling((double)actualDefense * percent);
        actualDefense += increase;

        Debug.Log("Actual Defense Boosted");
    }
    /*
        Decreases Defense stat by a given Percent
        Returns the amount the Defense was decreased by
    */
    public int decreaseActualDefenseByPercent(double percent) {
        int min = 1;
        int decrease = (int)Math.Ceiling((double)actualDefense * percent);
        if (actualDefense == min) {
            return 0;
        }
        else if (actualDefense - decrease < min) {
            int ret = actualDefense - min;
            actualDefense = min;
            return ret;
        }
        else {
            actualDefense -= decrease;
            return decrease;
        }
    }
    public int decreaseActualDefenseByPoints(int points) {
        if (actualDefense - points <= 1) {
            actualDefense = 1;
        } 
        else {
            actualDefense -= points;
        }
        return actualDefense;
    }
    public int increaseActualDefenseByPoints(int points) {
        actualDefense += points;
        return actualDefense;
    }

    public float getActualMoveSpeed() {
        return actualMoveSpeed;
    }

    



    public override void initializeItem()
    {
        //Get Item Clock
        ItemClock itemClock = GameObject.Find("Clock").GetComponent<ItemClock>();
        //Get any HeavyWeight Item already Active in Clock List
        HeavyWeight test = itemClock.getItemOfType<HeavyWeight>();
        //If there are none already Active
        if (test == default) {
            //Get Player GameObject
            player = GameObject.FindGameObjectWithTag("Player");
            //Get Player Attributes Script
            PlayerAttributes playerAttributes = player.GetComponent<PlayerAttributes>();
            //Get Player Controller Script
            Player playerContr = player.GetComponent<Player>();
            //Save the Player's actual Defense and MoveSpeed
            actualDefense = playerAttributes.defense;
            actualMoveSpeed = playerContr.moveSpeed;
            //Drop the Player's MoveSpeed, if possible
            bool success = playerContr.dropMoveSpeedByPercent(moveSpeedPercentDrop);
            //If the MoveSpeed Drop was successful
            if (success) {
                //Boost the Player's Defense
                playerAttributes.increaseDefenseByPercent(defensePercentBoost);
                //Increment Activation Time
                activationTime = DateTime.Now.AddMinutes(effectTime);
                //Add Item to Clock
                itemClock.addItem(this);

                //Get any SuperHuman Item if any exists
                SuperHuman sh = itemClock.getItemOfType<SuperHuman>();
                //If a SuperHuman Item does exists
                if (sh != default) {
                    //Set the Player's actual move speed to what is set in the SuperHuman Item
                    actualMoveSpeed = sh.getActualMoveSpeed();
                }

                Debug.Log("HeavyWeight Intialized and added to Clock");
            }
            //If the MoveSpeed Drop was not successful
            else {
                //Then nothing happens
                Debug.Log("HeavyWeight Initailized but not added to Clock");
            }
        }
        //If there is one already Active
        else {
            test.intensify();
        }
        
    }

    public override void activateItem()
    {
        //Get Player Attributes Script
        PlayerAttributes playerAttributes = player.GetComponent<PlayerAttributes>();
        //Get Player Controller Script
        Player playerContr = player.GetComponent<Player>();
        //Reset Player's Defense
        playerAttributes.defense = actualDefense;
        //Reset Player's MoveSpeed
        playerContr.moveSpeed = actualMoveSpeed;
        //Get the Item Clock
        ItemClock itemClock = GameObject.Find("Clock").GetComponent<ItemClock>();
        //Set Item to be Removed
        itemClock.addItemToRemove(this);

        Debug.Log("HeavyWeight Deactivated");
    }

    public override void intensify()
    {
        //Get Player Attributes Script
        PlayerAttributes playerAttributes = player.GetComponent<PlayerAttributes>();
        //Get Player Controller Script
        Player playerContr = player.GetComponent<Player>();
        //Drop the Player's MoveSpeed, if possible
        bool success = playerContr.dropMoveSpeedByPercent(moveSpeedPercentDrop);
        //If the MoveSpeed Drop was successful
        if (success) {
            //Boost the Player's Defense
            playerAttributes.increaseDefenseByPercent(defensePercentBoost);

            Debug.Log("HeavyWeight Intensified");
        }
        //If the MoveSpeed Drop was not successful
        else {
            //Then do nothing
            Debug.Log("HeavyWeight was not Intensified");
        }
    }
}
