using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClock : MonoBehaviour
{

    private DateTime nowTime;
    List<Item> items;
    List<Item> itemToRemove;


    // Start is called before the first frame update
    void Start()
    {
        nowTime = DateTime.Now;
        
        items = new List<Item>();
        itemToRemove = new List<Item>();

        //Testing Purposes
        // buildTestList();
    }

    // Update is called once per frame
    void Update()
    {
        nowTime = DateTime.Now;
        itemsTimeCompare();
        removeItems();
    }


    private void itemsTimeCompare() {

        foreach (Item i in items) {
            DateTime activationTime = i.getActivationTime();

            DateTime d1 = new DateTime(nowTime.Year, 
                                        nowTime.Month, 
                                        nowTime.Day, 
                                        nowTime.Hour, 
                                        nowTime.Minute, 
                                        nowTime.Second);

            DateTime d2 = new DateTime(activationTime.Year, 
                                        activationTime.Month, 
                                        activationTime.Day, 
                                        activationTime.Hour, 
                                        activationTime.Minute, 
                                        activationTime.Second);

            if (d2.CompareTo(d1) == 0) {
                i.activateItem();
            }
        }

    }




    public bool addItem(Item i) {

        bool newItem = true;

        foreach (Item item in items) {
            if (i.GetType() == item.GetType()) {
                newItem = false;
                item.intensify();
                break;
            }
        }

        if (newItem) {
            items.Add(i);
            return true;
        }
        return false;
    }

    public void addItemToRemove(Item i) {
        itemToRemove.Add(i);
    }

    private void removeItems() {

        foreach (Item remove in itemToRemove) {
            items.Remove(remove);
        }

    }

    public T getItemOfType<T>() {
        
        foreach (Item i in items) {
            if (i is T) {
                return (T)Convert.ChangeType(i, typeof(T));
            }
        }
        return default;

    }


    //For Testing Purposes
    private void buildTestList() {
        // Shock s1 = new Shock(999, "Shock", "Shocking", 5, 0.5, 20);
        // s1.initializeItem();

        // Shock s2 = new Shock(998, "Shock", "Shocking", 5, 2, 40);
        // s2.initializeItem();

        // Freeze f1 = new Freeze(1301, "Freeze", "Freeze", 5, 0.5, 5);
        // f1.initializeItem();

        // SuperHuman sh1 = new SuperHuman(7, "SupeHuman", "Boost", 5, 1);
        // sh1.initializeItem();

        // HeavyWeight hw1 = new HeavyWeight(1, "HeavyWeight", "HeavyWeight", 5, 2, 0.5, 0.1f);
        // hw1.initializeItem();
        // HeavyWeight hw2 = new HeavyWeight(1, "HeavyWeight", "HeavyWeight", 5, 2, 0.5, 0.15f);
        // hw2.initializeItem();

        // LifeSteal lf = new LifeSteal(18, "LifeSteal", "Heal from the suffering of others. ", 7, 0.5, 1);
        // lf.initializeItem();
    }
}
