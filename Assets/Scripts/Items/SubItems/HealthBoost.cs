using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class HealthBoost : Item
{

    [SerializeField]private double percentBoost;

    
    public HealthBoost(int itemID, string name, string description, int weight, int minWeight, int maxWeight, 
    double percentBoost) :
    base(itemID, name, description, weight) {
        
        // this.itemType = ItemType.Buff;
        this.percentBoost = percentBoost;

    }

    public HealthBoost(int itemID, string name, string description, int weight, 
    double percentBoost) :
    base(itemID, name, description, weight) {

        // this.itemType = ItemType.Buff;
        this.percentBoost = percentBoost;

    }


    public override string getIconPath() {
        return "Assets/Graphics/ItemIcons/HealthBoostIcon.png";
    }

    public override string getDescription() {
        return description + "\nHealth Boost: " + (percentBoost*100).ToString("##.#") + "%";
    }

    public double getPercentBoost() {
        return percentBoost;
    }
    


    public override void initializeItem() {

        PlayerAttributes playerAttributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();
        int newHealth = playerAttributes.increaseMaxHealthByPercent(percentBoost);
        Debug.Log("Health Boost " + itemID + " initialized\nNew Max Health: " + newHealth);
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
