using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{

    private double percentRestore; //for a percentage amount
    // private int restored;        //for a flat amount
   
    
    public HealthPotion(int itemID, string name, string description, int weight, int minWeight, int maxWeight, double percentRestore) : 
    base(itemID, name, description, weight, minWeight, maxWeight) {
        
        itemType = ItemType.Consumable;
        this.percentRestore = percentRestore;
        
    }
    
    public HealthPotion(int itemID, string name, string description, int weight, double percentRestore) : 
    base(itemID, name, description, weight) {
        
        itemType = ItemType.Consumable;
        this.percentRestore = percentRestore;
    }



    public double getPercentRestore() {
        return percentRestore;
    }

}
