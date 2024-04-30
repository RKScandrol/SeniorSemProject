using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class BubbleHealth : Item
{

    [SerializeField]private int bubbleHealth;


    public BubbleHealth(int itemID, string name, string description, int weight, 
    int bubbleHealth) : 
    base(itemID, name, description, weight)
    {
        this.bubbleHealth = bubbleHealth;
    }

    public BubbleHealth(int itemID, string name, string description, int weight, int minWeight, int maxWeight, 
    int bubbleHealth) : 
    base(itemID, name, description, weight, minWeight, maxWeight)
    {
        this.bubbleHealth = bubbleHealth;
    }

    

    public override string getDescription()
    {
        return description + "\nAdditional Bubble Health: " + bubbleHealth;
    }

    public override string getIconPath()
    {
        return "/ItemIcons/BubbleHealthIcon.png";
    }



    public override void initializeItem()
    {
        //Get the PlayerAttributes Component from the player_char GameObject
        PlayerAttributes playerAttributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();
        //Add bubbleHealth to PlayerAttributes' bubbleHealth
        playerAttributes.addBubbleHealth(bubbleHealth);

        Debug.Log("Bubble Health initialized");
    }




    //These should not be used
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
