using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType {      //Neccessary?
    Buff,
    Passive,
    Consumable
}

[Serializable]public abstract class Item {
    
    [SerializeField]protected int itemID;
    [SerializeField]protected string name;
    [SerializeField]protected string description;
    [SerializeField]protected int weight;
    protected int minWeight;
    protected int maxWeight;
    [SerializeField]protected Sprite icon;
    // protected ItemType itemType;


    public Item(int itemID, string name, string description, int weight, int minWeight, int maxWeight) {
        this.itemID = itemID;
        this.name = name;
        this.description = description;
        this.weight = weight;

        this.minWeight = minWeight;
        this.maxWeight = maxWeight;

        
    }

    public Item(int itemID, string name, string description, int weight) {
        this.itemID = itemID;
        this.name = name;
        this.description = description;
        this.weight = weight;

        this.minWeight = 0;
        this.maxWeight = 0;
    }


    public int getItemID() {
        return itemID;
    }
    public string getName() {
        return name;
    }
    public abstract string getDescription();    //Abstract Function

    public int getWeight() {
        return weight;
    }

    public int getMinWeight() {
        return minWeight;
    }
    public void setMinWeight(int newMinWeight) {
        if (newMinWeight < 0) {

        }
        else {
            this.minWeight = newMinWeight;
        }
    }

    public int getMaxWeight() {
        return maxWeight;
    }
    public void setMaxWeight(int newMaxWeight) {
        if (newMaxWeight < 0) {

        }
        else {
            this.maxWeight = newMaxWeight;
        }
    }

    // public ItemType getItemType() {
    //     return itemType;
    // }

    /* 
        Returns true if the itemID of the given item equals that of the current Item,
        Returns false otherwise
    */
    public bool compareItems(Item i) {
        if (itemID == i.getItemID()) {
            return true;
        }
        else {
            return false;
        }
    }


    public abstract void initializeItem();          //Abstract Function
    public abstract void activateItem();            //Abstract Function
    public abstract DateTime getActivationTime();   //Abstract Function
    public abstract string getIconPath();           //Abstract Function



}
