using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class HealthPotion : Item
{

    [SerializeField]private double percentRestore; //for a percentage amount
    // private int restored;        //for a flat amount
   
    
    public HealthPotion(int itemID, string name, string description, int weight, int minWeight, int maxWeight, 
    double percentRestore) : 
    base(itemID, name, description, weight, minWeight, maxWeight) {
        
        // itemType = ItemType.Consumable;
        this.percentRestore = percentRestore;
        
    }
    
    public HealthPotion(int itemID, string name, string description, int weight, 
    double percentRestore) : 
    base(itemID, name, description, weight) {
        
        // itemType = ItemType.Consumable;
        this.percentRestore = percentRestore;

    }


    public override string getIconPath() {
        return "/ItemIcons/HealthPotionIcon.png";
    }

    public override string getDescription() {
        return description + "\nHealth Restored: " + (percentRestore*100).ToString("##.#") + "%";
    }

    public double getPercentRestore() {
        return percentRestore;
    }
    


    public override void initializeItem() {

        PlayerAttributes playerAttributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();
        int health = playerAttributes.restoreHealthByPercent(percentRestore);

        Debug.Log("Health Potion " + itemID + " initialized\nNew Health Value: " + health);
    }



    //Should not be used
    public override void activateItem() {
        throw new NotImplementedException();
    }
    //Should not be used
    public override void intensify() {
        throw new NotImplementedException();
    }
    //Should not be used
    public override DateTime getActivationTime() {
        throw new NotImplementedException();
    }

}
