using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    LootTable lt;
    List<Item> items;


    // Start is called before the first frame update
    void Start()
    {
        items = new List<Item>();
        this.createItems();

        lt = new LootTable(items);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public LootTable getLootTable() {
        return lt;
    }


    private void createItems() {
        Item i1 = new Item(1, "Fireball", 6);
        Item i2 = new Item(2, "Health Potion", 6);
        Item i3 = new Item(3, "Shock", 6);
        Item i4 = new Item(4, "Water Balloon", 6);
        Item i5 = new Item(5, "Attack Potion", 6);
        Item i6 = new Item(6, "Speed Potion", 6);
        Item i7 = new Item(7, "Water", 6);
        Item i8 = new Item(8, "Taco", 6);
        Item i9 = new Item(9, "Purple Lizard", 6);

        items.Add(i1);
        items.Add(i2);
        items.Add(i3);
        items.Add(i4);
        items.Add(i5);
        items.Add(i6);
        items.Add(i7);
        items.Add(i8);
        items.Add(i9);
    }

    
}
