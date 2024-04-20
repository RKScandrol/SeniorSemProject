using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStatModifier 
{
    public static int playerHealthModifier(int baseHealth, int numBuffs) {
        double boostPercent = 0.25;
        return baseHealth + (int)Math.Ceiling(baseHealth * (boostPercent * numBuffs));
    }

    public static int playerAttackModifier(int baseAttack, int numBuffs) {
        double boostPercent = 0.25;
        return baseAttack + (int)Math.Ceiling(baseAttack * (boostPercent * numBuffs));
    }

    public static int playerDefenseModifier(int baseDefense, int numBuffs) {
        double boostPercent = 0.25;
        return baseDefense + (int)Math.Ceiling(baseDefense * (boostPercent * numBuffs));
    }
}
