using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class Shock : Item
{

    int timeIncrement;  //In Minutes
    DateTime activationTime;


    public Shock(int itemID, string name, string description, int weight, int minWeight, int maxWeight) :
    base(itemID, name, description, weight) {
        
        // this.itemType = ItemType.Passive;
    

    }

    public Shock(int itemID, string name, string description, int weight, int timeIncrement) :
    base(itemID, name, description, weight) {

        // this.itemType = ItemType.Passive;
        this.timeIncrement = timeIncrement;
        

    }

    public int getTimeIncrement() {
        return timeIncrement;
    }

    public DateTime getActivationTime() {
        return activationTime;
    }
    public void setActivationTime(DateTime activationTime) {
        this.activationTime = activationTime;
    }
    public void incrementActivationTime() {
        activationTime = activationTime.AddMinutes(timeIncrement);
    }


    

}
