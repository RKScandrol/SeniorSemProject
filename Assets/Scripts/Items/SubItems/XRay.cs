using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class XRay : Item
{
    public XRay(int itemID, string name, string description, int weight) : 
    base(itemID, name, description, weight)
    {

    }

    public XRay(int itemID, string name, string description, int weight, int minWeight, int maxWeight) : 
    base(itemID, name, description, weight, minWeight, maxWeight)
    {

    }

    public override void initializeItem()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies) {
            enemy.GetComponent<Transform>().Find("XRay").GetComponent<XRayStats>().showTxtStats();
        }
    }

    public override string getDescription()
    {
        return description;
    }

    public override string getIconPath()
    {
        return "Assets/Graphics/ItemIcons/XRayIcon.png";
    }


    //None of the Functions Below Should be called

    public override void activateItem()
    {
        throw new NotImplementedException();
    }

    public override DateTime getActivationTime()
    {
        throw new NotImplementedException();
    }

    public override void intensify()
    {
        throw new NotImplementedException();
    }
}
