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
        return description + "\nPercent Boost: " + (percentBoost*100) + "%";
    }

    public override string getIconPath()
    {
        return "Assets/Graphics/ItemIcons/TripleScoopIcon.png";
    }



    public override void initializeItem()
    {
        PlayerAttributes playerAttributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();
        playerAttributes.increaseAttackByPercent(percentBoost);
        playerAttributes.increaseDefenseByPercent(percentBoost);
        playerAttributes.increaseMaxHealthByPercent(percentBoost);

        //Get Item Clock
        ItemClock itemClock = GameObject.Find("Clock").GetComponent<ItemClock>();
        //Get any SuperHuman Item that might Exist
        SuperHuman sh = itemClock.getItemOfType<SuperHuman>();
        //If a SuperHuman Item does Exist
        if (sh != default) {
            //Boost the Player's Actual Attack stored in the Item
            sh.boostActualAttack(percentBoost);
        }
        //Get any HeavyWeight Item that might Exist
        HeavyWeight hw = itemClock.getItemOfType<HeavyWeight>();
        //If a HeavyWeight Item does Exist
        if (hw != default) {
            //Boost the Player's Actual Defense stored in the Item
            hw.boostActualDefense(percentBoost);
        }

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
