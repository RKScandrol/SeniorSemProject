using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class Shock : Item
{

    double timeIncrement;  //In Minutes
    DateTime activationTime;


    public Shock(int itemID, string name, string description, int weight, int minWeight, int maxWeight, 
    double timeIncrement, DateTime activationTime) :
    base(itemID, name, description, weight) {
        
        // this.itemType = ItemType.Passive;
        this.timeIncrement = timeIncrement;
        this.activationTime = activationTime;
    

    }

    public Shock(int itemID, string name, string description, int weight, 
    double timeIncrement) :
    base(itemID, name, description, weight) {

        // this.itemType = ItemType.Passive;
        this.timeIncrement = timeIncrement;
        

    }

    public double getTimeIncrement() {
        return timeIncrement;
    }

    public override DateTime getActivationTime() {
        return activationTime;
    }
    public void setActivationTime(DateTime activationTime) {
        this.activationTime = activationTime;
    }
    public void incrementActivationTime() {
        activationTime = activationTime.AddMinutes(timeIncrement);
    }


    public override void initializeItem() {
        setActivationTime(DateTime.Now.AddMinutes(timeIncrement));
    }

    public override void activateItem() {
        incrementActivationTime();
    }


    

}
