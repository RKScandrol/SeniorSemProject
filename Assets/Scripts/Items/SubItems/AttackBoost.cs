using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class AttackBoost : Item
{

    [SerializeField]private double percentBoost;


    public AttackBoost(int itemID, string name, string description, int weight, int minWeight, int maxWeight, 
    double percentBoost) :
    base(itemID, name, description, weight) {
        
        this.percentBoost = percentBoost;

    }

    public AttackBoost(int itemID, string name, string description, int weight, 
    double percentBoost) :
    base(itemID, name, description, weight) {

        this.percentBoost = percentBoost;

    }


    public override string getIconPath() {
        return "Assets/Graphics/ItemIcons/AttackBoostIcon.png";
    }

    public override string getDescription() {
        return description + "\nAttack Boost: " + (percentBoost*100).ToString("##.#") + "%";
    }

    public double getPercentBoost() {
        return percentBoost;
    }
    


    public override void initializeItem() {
        //Boost the PLayer's Attack
        PlayerAttributes playerAttributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();
        int newAttack = playerAttributes.increaseAttackByPercent(percentBoost);

        /*
            Check if the player has chosen the SuperHuman item, 
            which temporarily boosts the attack stat 
            but stores the actual attack,
            If so, boost the actual attack as well
        */
        ItemClock itemClock = GameObject.Find("Clock").GetComponent<ItemClock>();
        SuperHuman sh = itemClock.getItemOfType<SuperHuman>();

        if (sh != default) {
            sh.boostActualAttack(percentBoost);
        }

        //For Testing
        Debug.Log("Attack Boost " + itemID + " initialized\nNew Attack Value: " + newAttack);
    }



    //Should not be used
    public override void activateItem() 
    {
        throw new NotImplementedException();
    }
    //Should not be used
    public override void intensify() 
    {
        throw new NotImplementedException();
    }
    //Should not be used
    public override DateTime getActivationTime()
    {
        throw new NotImplementedException();
    }
    

}
