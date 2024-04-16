using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LootTable {
    
    public Item[] items;
    private int totalWeight;


    public LootTable () {
        totalWeight = 0;
        items = JsonHelper.getLootTable();

        createTable();
    }
    public LootTable (Item[] items) {
        this.items = items;
        totalWeight = 0;

        createTable();
    }



    private void createTable() {

        if (items != null && items.Length > 0) {

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


    public Item pickItem() {

        if (items != null && items.Length > 0) {

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
        else {
            return null;
        }

    }

}
