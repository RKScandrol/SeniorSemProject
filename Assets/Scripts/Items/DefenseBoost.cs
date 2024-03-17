using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class DefenseBoost : Item
{
    
    [SerializeField]private double percentBoost;


    public DefenseBoost(int itemID, string name, string description, int weight, int minWeight, int maxWeight, double percentBoost) :
    base(itemID, name, description, weight) {
        
        // this.itemType = ItemType.Buff;
        this.percentBoost = percentBoost;

    }

    public DefenseBoost(int itemID, string name, string description, int weight, double percentBoost) :
    base(itemID, name, description, weight) {

        // this.itemType = ItemType.Buff;
        this.percentBoost = percentBoost;

    }


    public double getPercentBoost() {
        return percentBoost;
    }

}