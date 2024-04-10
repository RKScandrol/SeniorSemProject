using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class SlipNSlide : Item
{


    private float tempLinearDrag = 0.0001f;
    private float actualLinearDrag = 1.5f;
    [SerializeField]private double effectTime;  //In Minutes
    private DateTime activationTime;    //EndTime for the Effect


    public SlipNSlide(int itemID, string name, string description, int weight, 
    double effectTime) : 
    base(itemID, name, description, weight)
    {
        this.effectTime = effectTime;
        this.tempLinearDrag = 0.0001f;
        this.actualLinearDrag = 1.5f;
    }

    public SlipNSlide(int itemID, string name, string description, int weight, int minWeight, int maxWeight, 
    float tempLinearDrag, float actualLinearDrag, double effectTime, DateTime activationTime) : 
    base(itemID, name, description, weight, minWeight, maxWeight)
    {
        this.tempLinearDrag = tempLinearDrag;
        this.actualLinearDrag = actualLinearDrag;
        this.effectTime = effectTime;
        this.activationTime = activationTime;
    }

    

    public override DateTime getActivationTime()
    {
        return activationTime;
    }

    public override string getDescription()
    {
        return description + "\nEffect Time: " + effectTime + " minutes";
    }

    public override string getIconPath()
    {
        return "";
    }



    public override void initializeItem()
    {
        this.tempLinearDrag = 0.001f;
        this.actualLinearDrag = 1.5f;
        //Get all the enemies in the level
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //For each enemy
        foreach (GameObject enemy in enemies) {
            //Get the RigidBoby2D component
            Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
            //And adjust the Linear Drag for each Enemy
            rb.drag = tempLinearDrag;
        }
        //Get the Item Clock
        ItemClock itemClock = GameObject.Find("Clock").GetComponent<ItemClock>();
        //And add the Item to the Clock
        itemClock.addItem(this);
        //Increment ActivationTime to the current Time by EffectTime
        activationTime = DateTime.Now.AddMinutes(effectTime);


        Debug.Log("Slip and Slide Initialized");

    }

    public override void activateItem()
    {
        //Get all the enemies in the level
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //For each Enemy that still exists
        foreach (GameObject enemy in enemies) {
            //Get the RigidBody2D component
            Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
            //Reset the Linear Drag
            rb.drag = actualLinearDrag;
        }
        //Get the Item Clock
        ItemClock itemClock = GameObject.Find("Clock").GetComponent<ItemClock>();
        //Set the Item to be removed from the Clock
        itemClock.addItemToRemove(this);
        //Increment ActivationTime
        activationTime = activationTime.AddMinutes(effectTime);


        Debug.Log("Slip and Slide deactivated");
    }

    public override void intensify()
    {
        //If SlipNSlide Item is Intensified, increase the ActivationTime (EndTime) by half of the EffectTime
        activationTime = activationTime.AddMinutes(effectTime/2);


        Debug.Log("Slip and Slide intensified");
    }
}
