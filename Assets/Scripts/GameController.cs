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
        Item i1 = new Item("Fireball", 6);
        Item i2 = new Item("Health Potion", 6);
        Item i3 = new Item("Shock", 6);
        Item i4 = new Item("Water Balloon", 6);
        Item i5 = new Item("Attack Potion", 6);
        Item i6 = new Item("Speed Potion", 6);
        Item i7 = new Item("Water", 6);
        Item i8 = new Item("Taco", 6);
        Item i9 = new Item("Purple Lizard", 6);

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
