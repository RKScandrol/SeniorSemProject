using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{


    LootTable lt;
    Item[] items = new Item[5];


    // Start is called before the first frame update
    void Start()
    {
        // this.createItems();
        // this.writeItems();
        // this.readItems();
        // lt = new LootTable(items);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public LootTable getLootTable() {
        return lt;
    }


    private void createItems() {

        //Original Code:

        // Item i1 = new Item(1, "Fireball", "Throw a Fireball", 6);
        // Item i2 = new Item(2, "Health Potion", "Heal Yourself", 6);
        // Item i3 = new Item(3, "Shock", "Shock your Enemies", 6);
        // Item i4 = new Item(4, "Water Balloon", "Have Fun!", 6);
        // Item i5 = new Item(5, "Attack Potion", "Just Hit them Harder", 6);
        // Item i6 = new Item(6, "Speed Potion", "Gotta Go Fast", 6);
        // Item i7 = new Item(7, "Water", "Holy?", 6);
        // Item i8 = new Item(8, "Taco", "Party", 6);
        // Item i9 = new Item(9, "Purple Lizard", "Friend", 6);

        // items.Add(i1);
        // items.Add(i2);
        // items.Add(i3);
        // items.Add(i4);
        // items.Add(i5);
        // items.Add(i6);
        // items.Add(i7);
        // items.Add(i8);
        // items.Add(i9);


        //Now Using:

        // HealthPotion hp1 = new HealthPotion(1, "Health Potion", "Increase Health by a Percentage", 10, 0.1);
        // items[0] = hp1;
        // AttackBoost ab1 = new AttackBoost(2, "Attck Boost", "Learn How to Hit Harder", 7, 0.15);
        // items[1] = ab1;
        // HealthBoost hb1 = new HealthBoost(3, "Health Boost", "Drink this for Increased Life", 5, 0.2);
        // items[2] = hb1;
        // DefenseBoost db1 = new DefenseBoost(4, "Defense Boost", "Toughen Up", 8, 0.2);
        // items[3] = db1;
        // Shock s1 = new Shock(5, "Shock", "Shock Your Enemies", 5);
        // items[4] = s1;
    }


    private void writeItems() {

        string filename = Application.dataPath + "/items.json";

        
        string jsonStr = JsonHelper.ToJson(items, true);
        File.WriteAllText(filename, jsonStr);

        // File.AppendAllText(filename, "[\n");

        // foreach (Item i in items) {
        //     string j = JsonUtility.ToJson(i);
            
        //     File.AppendAllText(filename, j);

        //     if (items.IndexOf(i) != items.Count-1) {
        //         File.AppendAllText(filename, ",\n");
        //     }
        // }

        // File.AppendAllText(filename, "\n]");
    }

    private void readItems() {

        string filename = Application.dataPath + "/items.json";
        string[] lines = File.ReadAllLines(filename);
        string line = "";
        foreach (string l in lines) {
            line += l;
        }

        items = JsonHelper.FromJson<Item>(line);


        // foreach (string line in lines) {

        //     if (line.Equals("[") || line.Equals("]")) {
        //         continue;
        //     }
        //     else {
                
        //         Item i = JsonUtility.FromJson<Item>(line);
        //         items.Add(i);
        //     }

        // }
    }

    
}


