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

        PlayerAttributes playerAttributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();
        int newAttack = playerAttributes.increaseAttackByPercent(percentBoost);

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
