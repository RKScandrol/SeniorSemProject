using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHistory
{

    public int numHealthBuffsBought;
    public int numAttackBuffsBought;
    public int numDefenseBuffsBought;


    public BuyHistory(int numHealthBuffsBought, int numAttackBuffsBought, int numDefenseBuffsBought) {
        this.numHealthBuffsBought = numHealthBuffsBought;
        this.numAttackBuffsBought = numAttackBuffsBought;
        this.numDefenseBuffsBought = numDefenseBuffsBought;
    }

    public BuyHistory() {
        this.numHealthBuffsBought = 0;
        this.numAttackBuffsBought = 0;
        this.numDefenseBuffsBought = 0;
    }


    public void incrementNumHealthBuffsBought() {
        numHealthBuffsBought++;
    }
    public void incrementNumAttackBuffsBought() {
        numAttackBuffsBought++;
    }
    public void incrementNumDefenseBuffsBought() {
        numDefenseBuffsBought++;
    }

    
}
