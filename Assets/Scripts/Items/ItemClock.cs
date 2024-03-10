using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClock : MonoBehaviour
{

    private DateTime nowTime;
    private DateTime checkTime;
    List<Item> items;


    // Start is called before the first frame update
    void Start()
    {
        nowTime = DateTime.Now;
        Debug.Log("NowTime: " + nowTime.ToString());
        checkTime = nowTime.AddMinutes(1);
        Debug.Log("CheckTIme: " + checkTime.ToString());


        items = new List<Item>();

        //Testing Purposes
        buildTestList();
    }

    // Update is called once per frame
    void Update()
    {
        nowTime = DateTime.Now;
        itemsTimeCompare();
    }


    //For Testing Purposes
    private void timeCompareTest() {

        DateTime d1 = new DateTime(nowTime.Year, 
                                    nowTime.Month, 
                                    nowTime.Day, 
                                    nowTime.Hour, 
                                    nowTime.Minute, 
                                    nowTime.Second);

        DateTime d2 = new DateTime(checkTime.Year, 
                                    checkTime.Month, 
                                    checkTime.Day, 
                                    checkTime.Hour, 
                                    checkTime.Minute, 
                                    checkTime.Second);
        // Debug.Log("d1:" + d1.ToString());
        // Debug.Log("d2: " + d2.ToString());

        if (d2.CompareTo(d1) == 0) {
            Debug.Log("Times Match, adding another minute\n" + nowTime.ToString() + "\n");
            checkTime = checkTime.AddMinutes(1);
        }
        else if (checkTime.CompareTo(nowTime) < 0) {
            // Debug.Log("Too Late\n" + nowTime.ToString() + "\n");
        }
        else {
            // Debug.Log("Too Early\n" + nowTime.ToString() + "\n");
        }
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
                Debug.Log("Activating Shock ID: " + i.getItemID());
                i.activateItem();
            }
        }

    }




    public void addItem(Item i) {
        // items.Add(i);
    }


    //For Testing Purposes
    private void buildTestList() {
        Shock s1 = new Shock(999, "Shock", "Shocking", 5, 1);
        items.Add(s1);
        s1.initializeItem();

        Shock s2 = new Shock(998, "Shock", "Shocking", 5, 2);
        items.Add(s2);
        s2.initializeItem();
    }
}
