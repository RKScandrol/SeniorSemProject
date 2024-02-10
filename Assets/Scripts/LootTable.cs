using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable {
    
    public List<Item> items;
    private int totalWeight;


    public LootTable () {
        this.items = new List<Item>();
        this.totalWeight = 0;
    }
    public LootTable (List<Item> items) {
        this.items = items;
        this.totalWeight = 0;
    }



    private void createTable() {
        if (items != null && items.Count > 0) {

            foreach (Item i in items) {

                if (i.getWeight() < 0) {
                    
                }
                else {
                    i.setMinWeight(totalWeight);
                    totalWeight += i.getWeight();
                    i.setMaxWeight(totalWeight);
                }

            }

        }
    }

    public void addItem(Item i) {
        items.Add(i);
        this.addItem(i);
    }


    private void updateTable(Item i) {
        if (i.getWeight() < 0) {
                    
        }
        else {
            i.setMinWeight(totalWeight);
            totalWeight += i.getWeight();
            i.setMaxWeight(totalWeight);
        }
    }


    public Item pickItem() {

        System.Random rnd = new System.Random();

        //Returns an int >= 0 and < totalWeight of all items in table
        int randInt = rnd.Next(0, totalWeight);

        foreach (Item i in items) {

            if (randInt >= i.getMinWeight() && randInt < i.getMaxWeight() ) {
                return i;
            }

        }

        return items[0];

    }

}
