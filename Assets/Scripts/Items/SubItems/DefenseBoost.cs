using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class DefenseBoost : Item
{
    
    [SerializeField]private double percentBoost;


    public DefenseBoost(int itemID, string name, string description, int weight, int minWeight, int maxWeight, 
    double percentBoost) :
    base(itemID, name, description, weight) {
        
        // this.itemType = ItemType.Buff;
        this.percentBoost = percentBoost;

    }

    public DefenseBoost(int itemID, string name, string description, int weight, 
    double percentBoost) :
    base(itemID, name, description, weight) {

        // this.itemType = ItemType.Buff;
        this.percentBoost = percentBoost;

    }


    public override string getDescription() {
        return description + "\nDefense Boost: " + (percentBoost*100).ToString("##.#") + "%";
    }

    public double getPercentBoost() {
        return percentBoost;
    }
    public override DateTime getActivationTime() {
        return new DateTime(1, 1, 1, 1, 1, 1);
    }


    public override void initializeItem() {
        Debug.Log("Defense Boost " + itemID + " initialized");
    }

    public override void activateItem() {

    }

}
