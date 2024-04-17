using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class PermUpgradeSystem : MonoBehaviour
{

    public GameObject permUpgradeMenu;
    public TMP_Text txtHealthDesc;
    public TMP_Text btntxtHealth;
    public TMP_Text txtAttackDesc;
    public TMP_Text btntxtAttack;
    public TMP_Text txtDefenseDesc;
    public TMP_Text btntxtDefense;
    private GoldUISystem goldUISystem;
    private int healthBuffCost;
    private int attackBuffCost;
    private int defenseBuffCost;
    private BuyHistory buyHistory;


    // Start is called before the first frame update
    void Start()
    {

        goldUISystem = GameObject.Find("GoldUI").GetComponent<GoldUISystem>();
        readBuyHistory();

        priceCalculation();

        setAllText();
        calculatePurchasePower();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setHealthDescription() {
        txtHealthDesc.text = "Boost your Health" 
            + "Current Player Health: h1" 
            + "\nIncrease Percent: x"
            + "\nNew Player Health: h2";
    }

    public void setHealthBtnText() {
        btntxtHealth.text = healthBuffCost + " Gold";
    }

    public void setHealthText() {
        setHealthDescription();
        setHealthBtnText();
    }



    public void setAttackDescription() {
        txtAttackDesc.text = "Boost your Attack"
            + "Current Player Attack: a1" 
            + "\nIncrease Percent: y"
            + "\nNew Player Attack: a2";
    }

    public void setAttackBtnText() {
        btntxtAttack.text = attackBuffCost + " Gold";
    }

    public void setAttackText() {
        setAttackDescription();
        setAttackBtnText();
    }



    public void setDefenseDescription() {
        txtDefenseDesc.text = "Boost your Defense" 
            + "Current Player Defense: d1" 
            + "\nIncrease Defense: z"
            + "\nNew Player Defense: d2";
    }

    public void setDefenseBtnText() {
        btntxtDefense.text = defenseBuffCost + " Gold";
    }

    public void setDefenseText() {
        setDefenseDescription();
        setDefenseBtnText();
    }



    public void setAllText() {
        setHealthText();
        setAttackText();
        setDefenseText();
    }


    public void calculatePurchasePower() {

        int gold = goldUISystem.gold;

        if (gold >= healthBuffCost) {
            btntxtHealth.color = Color.green;
        }
        else {
            btntxtHealth.color = Color.red;
        }

        if (gold >= attackBuffCost) {
            btntxtAttack.color = Color.green;
        }
        else {
            btntxtAttack.color = Color.red;
        }

        if (gold >= defenseBuffCost) {
            btntxtDefense.color = Color.green;
        }
        else {
            btntxtDefense.color = Color.red;
        }

    }



    public void priceCalculation() {
        int baseVal = 10;

        healthBuffCost = baseVal + (int)Math.Floor(baseVal * (buyHistory.numHealthBuffsBought * 0.5) );
        attackBuffCost = baseVal + (int)Math.Floor(baseVal * (buyHistory.numAttackBuffsBought * 0.5) );
        defenseBuffCost = baseVal + (int)Math.Floor(baseVal * (buyHistory.numDefenseBuffsBought * 0.5) );
    }



    public void buffHealth() {
        /*
            This function should buff the Base Health stat from Player Attributes
        */
        int gold = goldUISystem.gold;

        if (gold >= healthBuffCost) {

            // Buff Goes here

            goldUISystem.decreaseGold(healthBuffCost);
            buyHistory.incrementNumHealthBuffsBought();
            priceCalculation();
            setHealthText();
            calculatePurchasePower();
        }
    }

    public void buffAttack() {
        /*
            This function should buff the Base Attack stat from Player Attributes
        */
        int gold = goldUISystem.gold;

        if (gold >= attackBuffCost) {
            goldUISystem.decreaseGold(attackBuffCost);
            buyHistory.incrementNumAttackBuffsBought();
            priceCalculation();
            setAttackText();
            calculatePurchasePower();
        }
    }

    public void buffDefense() {
        /*
            This function should buff the Base Defense stat from Player Attributes
        */
        int gold = goldUISystem.gold;

        if (gold >= defenseBuffCost) {
            goldUISystem.decreaseGold(defenseBuffCost);
            buyHistory.incrementNumDefenseBuffsBought();
            priceCalculation();
            setDefenseText();
            calculatePurchasePower();
        }
    }



    public void exitMenu() {
        permUpgradeMenu.SetActive(false);



        string jsonStr = JsonUtility.ToJson(buyHistory, true);
        string path = Application.dataPath + "/Scripts/PermUpgrades/BuyHistory.json";
        File.WriteAllText(path, jsonStr);
        // Debug.Log(path + "\n" + jsonStr);

    }


    public void readBuyHistory() {
        string path = Application.dataPath + "/Scripts/PermUpgrades/BuyHistory.json";
        string[] lines = File.ReadAllLines(path);
        string jsonStr = attachJsonLines(lines);
        buyHistory = JsonUtility.FromJson<BuyHistory>(jsonStr);
    }

    private string attachJsonLines(string[] lines) {
        string jsonStr = "";
        foreach (string line in lines) {
            jsonStr += line;
        }
        return jsonStr;
    }



    
}
