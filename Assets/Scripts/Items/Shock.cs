using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shock : Item
{


    public Shock(int itemID, string name, string description, int weight, int minWeight, int maxWeight) :
    base(itemID, name, description, weight) {
        
        this.itemType = ItemType.Passive;
    

    }

    public Shock(int itemID, string name, string description, int weight) :
    base(itemID, name, description, weight) {

        this.itemType = ItemType.Passive;
        

    }


    

}
