using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    
    protected String name;
    protected int weight;
    protected int minWeight;
    protected int maxWeight;



    public Item(String name, int weight) {
        this.name = name;
        this.weight = weight;

        this.minWeight = 0;
        this.maxWeight = 0;
    }



    public String getName() {
        return name;
    }

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

}