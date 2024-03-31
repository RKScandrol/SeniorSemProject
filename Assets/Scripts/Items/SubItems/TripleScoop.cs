using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class TripleScoop : Item
{

    [SerializeField]private double percentBoost;


    public TripleScoop(int itemID, string name, string description, int weight, 
    double percentBoost) : 
    base(itemID, name, description, weight)
    {
        this.percentBoost = percentBoost;
    }

    public TripleScoop(int itemID, string name, string description, int weight, int minWeight, int maxWeight, 
    double percentBoost) : 
    base(itemID, name, description, weight, minWeight, maxWeight)
    {
        this.percentBoost = percentBoost;
    }

    

    public override string getDescription()
    {
        return description;
    }

    public override string getIconPath()
    {
        return "";
    }



    public override void initializeItem()
    {
        PlayerAttributes playerAttributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();
        playerAttributes.increaseAttackByPercent(percentBoost);
        playerAttributes.increaseDefenseByPercent(percentBoost);
        playerAttributes.increaseMaxHealthByPercent(percentBoost);

        Debug.Log("Triple Scoop " + itemID + " intialized");
    }


    //Should not be used
    public override DateTime getActivationTime()
    {
        throw new NotImplementedException();
    }
    //Should not be used
    public override void activateItem()
    {
        throw new NotImplementedException();
    }
    //Should not be used
    public override void intensify()
    {
        throw new NotImplementedException();
    }
}
