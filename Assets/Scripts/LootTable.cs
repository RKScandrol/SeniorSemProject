using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{

    public List<Item> items;
    private int totalWeight;


    public LootTable() {
        this.items = new List<Item>();
        this.totalWeight = 0;
        this.createTable();
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

        //Returns an int >= 0 and < totalWeight of all items in table
        int randInt = Random.Range(0, totalWeight);

        foreach (Item i in items) {

            if (randInt >= i.getMinWeight() && randInt < i.getMaxWeight() ) {
                return i;
            }

        }

        return items[0];

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
