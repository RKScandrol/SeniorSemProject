using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class PermUpgradeSystem : MonoBehaviour
{

    public GameObject permUpgradeMenu;
    public TMP_Text txtHealthDesc;
    public TMP_Text btntxtHealth;
    public TMP_Text txtAttackDesc;
    public TMP_Text btntxtAttack;
    public TMP_Text txtDefenseDesc;
    public TMP_Text btntxtDefense;
    public GoldUISystem goldUISystem;
    private int healthBuffCost;
    private int attackBuffCost;
    private int defenseBuffCost;
    private BuyHistory buyHistory; 
    private PlayerBaseStats playerBaseStats;
    public int gold;
    private string goldJsonPath;


    // Start is called before the first frame update
    IEnumerator Start()
    {

        yield return new WaitUntil(() => goldUISystem.isInit);

        goldUISystem = GameObject.Find("GoldUI").GetComponent<GoldUISystem>();
        readBuyHistory();

        readPlayerBaseStats();

        goldJsonPath = "/Scripts/Player/Gold.json";
        getGoldFromJson();

        priceCalculation();

        setAllText();
        calculatePurchasePower();

        Debug.Log("permUpgrade loaded");

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setHealthDescription() {
        txtHealthDesc.text = "Boost your Health" 
            + "\nCurrent Player Health: " 
            + PlayerStatModifier.playerHealthModifier(playerBaseStats.health, buyHistory.numHealthBuffsBought)
            + "\nNew Player Health: "
            + PlayerStatModifier.playerHealthModifier(playerBaseStats.health, buyHistory.numHealthBuffsBought + 1);
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
            + "\nCurrent Player Attack: "
            + PlayerStatModifier.playerAttackModifier(playerBaseStats.attack, buyHistory.numAttackBuffsBought) 
            + "\nNew Player Attack: " 
            + PlayerStatModifier.playerAttackModifier(playerBaseStats.attack, buyHistory.numAttackBuffsBought + 1);
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
            + "\nCurrent Player Defense: " 
            + PlayerStatModifier.playerDefenseModifier(playerBaseStats.defense, buyHistory.numDefenseBuffsBought) 
            + "\nNew Player Defense: " 
            + + PlayerStatModifier.playerDefenseModifier(playerBaseStats.defense, buyHistory.numDefenseBuffsBought + 1);
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

        if (gold >= healthBuffCost) {

            // Buff Goes here

            gold -= healthBuffCost;
            buyHistory.incrementNumHealthBuffsBought();
            priceCalculation();
            setHealthText();
            calculatePurchasePower();
            goldUISystem.setText(gold);
        }
    }

    public void buffAttack() {
        /*
            This function should buff the Base Attack stat from Player Attributes
        */

        if (gold >= attackBuffCost) {
            gold -= attackBuffCost;
            buyHistory.incrementNumAttackBuffsBought();
            priceCalculation();
            setAttackText();
            calculatePurchasePower();
            goldUISystem.setText(gold);
        }
    }

    public void buffDefense() {
        /*
            This function should buff the Base Defense stat from Player Attributes
        */

        if (gold >= defenseBuffCost) {
            gold -= defenseBuffCost;
            buyHistory.incrementNumDefenseBuffsBought();
            priceCalculation();
            setDefenseText();
            calculatePurchasePower();
            goldUISystem.setText(gold);
        }
    }



    public void exitMenu() {
        permUpgradeMenu.SetActive(false);



        string jsonStr = JsonUtility.ToJson(buyHistory, true);
        string path = Application.dataPath + "/Scripts/PermUpgrades/BuyHistory.json";
        File.WriteAllText(path, jsonStr);

        writeGoldToJson();

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

    private void readPlayerBaseStats() {
        string playerStatsPath = Application.dataPath + "/Scripts/Player/PlayerStats.json";
        string jsonStr = File.ReadAllText(playerStatsPath);
        playerBaseStats = JsonUtility.FromJson<PlayerBaseStats>(jsonStr);
    }

    private void getGoldFromJson() {
        string jsonStr = File.ReadAllText(Application.dataPath + goldJsonPath);
        int[] golds = JsonHelper.FromJson<int>(jsonStr);
        gold = golds[0];

        goldUISystem.setText(gold);
    }

    private void writeGoldToJson() {
        int[] golds = new int[1];
        golds[0] = gold;

        string jsonStr = JsonHelper.ToJson(golds, true);
        File.WriteAllText(Application.dataPath + goldJsonPath, jsonStr);
    }

    public int getGold() {
        return gold;
    }



    
}
