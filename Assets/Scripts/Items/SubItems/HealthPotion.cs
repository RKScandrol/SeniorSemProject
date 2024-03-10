using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class HealthPotion : Item
{

    [SerializeField]private double percentRestore; //for a percentage amount
    // private int restored;        //for a flat amount
   
    
    public HealthPotion(int itemID, string name, string description, int weight, int minWeight, int maxWeight, double percentRestore) : 
    base(itemID, name, description, weight, minWeight, maxWeight) {
        
        // itemType = ItemType.Consumable;
        this.percentRestore = percentRestore;
        
    }
    
    public HealthPotion(int itemID, string name, string description, int weight, double percentRestore) : 
    base(itemID, name, description, weight) {
        
        // itemType = ItemType.Consumable;
        this.percentRestore = percentRestore;
    }


    public override string getDescription() {
        return description + "\nHealth Restored: " + (percentRestore*100).ToString("##.#") + "%";
    }

    public double getPercentRestore() {
        return percentRestore;
    }
    public override DateTime getActivationTime() {
        return new DateTime(1, 1, 1, 1, 1, 1);
    }


    public override void initializeItem() {
        Debug.Log("Health Potion " + itemID + " initialized");
    }

    public override void activateItem() {

    }

}
