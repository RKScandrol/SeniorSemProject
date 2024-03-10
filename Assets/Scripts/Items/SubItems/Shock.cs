using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class Shock : Item
{

    double timeIncrement;  //In Minutes
    DateTime activationTime;
    int damage;



    public Shock(int itemID, string name, string description, int weight, int minWeight, int maxWeight, 
    double timeIncrement, DateTime activationTime, int damage) :
    base(itemID, name, description, weight) {
        
        // this.itemType = ItemType.Passive;
        this.timeIncrement = timeIncrement;
        this.activationTime = activationTime;
        this.damage = damage;
    
    }

    public Shock(int itemID, string name, string description, int weight, 
    double timeIncrement, int damage) :
    base(itemID, name, description, weight) {

        // this.itemType = ItemType.Passive;
        this.timeIncrement = timeIncrement;
        this.damage = damage;

    }


    public override string getIconPath() {
        return "Assets/Graphics/ItemIcons/ShockIcon.png";
    }

    public override string getDescription() {
        return description + "\nAttack Power: " + damage + "\nWait Time: " + timeIncrement + " minutes";
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
        Debug.Log("Shock " + itemID + " initialized");

        GameObject gameClock = GameObject.Find("Clock");
        ItemClock itemClock = gameClock.GetComponent<ItemClock>();

        itemClock.addItem(this);
    }

    public override void activateItem() {
        incrementActivationTime();
        Debug.Log("Shock Activated");

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Vector2 guyPos = GameObject.Find("guy").GetComponent<Transform>().position;

        string closestName = enemies[0].name;
        float distance = Vector2.Distance(guyPos, enemies[0].GetComponent<Transform>().position);

        for (int i = 1 ; i < enemies.Length ; i++) {
            float checkDist = Vector2.Distance(guyPos, enemies[i].GetComponent<Transform>().position);

            if (checkDist < distance) {
                distance = checkDist;
                closestName = enemies[i].name;
            }
        }

        
        GameObject enemy = GameObject.Find(closestName);

        Animator animator = enemy.GetComponent<Animator>();
        animator.Play("shocked");
        

    }


    

}
