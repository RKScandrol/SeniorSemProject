using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;
using UnityEditor;

public class ChestMessage : MonoBehaviour
{
    public GameObject ui;

	public TMP_Text txtItem1Name;
	public TMP_Text txtItem1Des;
	public RawImage imgItem1;

    public TMP_Text txtItem2Name;
	public TMP_Text txtItem2Des;
	public RawImage imgItem2;

    public TMP_Text txtItem3Name;
	public TMP_Text txtItem3Des;
	public RawImage imgItem3;

	private Item item1;
	private Item item2;
	private Item item3;

	private GameObject chest;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Open(GameObject chest) {

		this.chest = chest;
		
		ui.SetActive (!ui.activeSelf);

		if (ui.activeSelf) {

			/*
				Previously the RawImages were simply made white
			*/
			// RawImage rawImage = ui.gameObject.GetComponentInChildren<RawImage>();
			// rawImage.color = Color.white;

			/*
				Previously GameController script created and populated LootTable
			*/
			// GameObject g = GameObject.Find("GameController");
			// GameController gc = g.GetComponent<GameController>();
			// LootTable lt = gc.getLootTable();

			/*
				LootTable is created and populated only after chest is opened
			*/
			LootTable lt = new LootTable();
			

			item1 = lt.pickItem();	//Get 1st random Item from LootTable

			do {
				item2 = lt.pickItem();		//Get 2nd random Item from LootTable
			} while (item2.compareItems(item1));	//If item2 has the same ID as item1, loop back to pick new Item

			do {
				item3 = lt.pickItem();		//Get 3rd random Item from LootTable
			} while (item3.compareItems(item1) || item3.compareItems(item2));	//If item3 has the same ID as either item1 or 2, loop back to pick new Item
			
			// item1 = new Shock(999, "Shock", "Shocking", 1, 1, 1);	//For testing purposes
			// item1 = new OHKO(1919, "OHKO", "Carefull", 100, 3, 20, 0.2);
			// item1 = new AttackBoost(1919, "Attack Boost", "hit harder", 5, 0.25);
			// item2 = new SuperHuman(7, "SupeHuman", "Boost", 5, 1, 0.25, 0.25f);
			// item1 = new HeavyWeight(1, "HeavyWeight", "HeavyWeight", 5, 2, 0.5, 0.5f);
			// item1 = new AttackDefenseTradeOff(7, "TradeOff", "Trade Defense for Attack", 7, 0.4);
			// item1 = new SlipNSlide(17, "Slip and Slide", "weeeee!", 5, 1.0);
			// item2 = new XRay(18, "Xray", "See Enemy Stats", 5);
			
			txtItem1Name.text = "" + item1.getName(); 
			txtItem1Des.text = "" + item1.getDescription();
			txtItem2Name.text = "" + item2.getName(); 
			txtItem2Des.text = "" + item2.getDescription();
			txtItem3Name.text = "" + item3.getName(); 
			txtItem3Des.text = "" + item3.getDescription();


			
			imgItem1.texture = IMG2Sprite.LoadTexture(item1.getIconPath());
			imgItem2.texture = IMG2Sprite.LoadTexture(item2.getIconPath());
			imgItem3.texture = IMG2Sprite.LoadTexture(item3.getIconPath());
            
			Time.timeScale = 0f;
		} 
	}

	private string readJsonFile() {
		string filename = Application.dataPath + "/Scripts/JsonItems/items.json";
        string[] lines = File.ReadAllLines(filename);
        string line = "";
        foreach (string l in lines) {
            line += l;
        }
		return line;
	}




	public void chooseItem1() {
		
		/*
			This should take item1 from above and give/apply to the player
			Need more work on Player first
		*/
		item1.initializeItem();

		Close();
	}
	public void chooseItem2() {
		
		/*
			This should take item2 from above and give/apply to the player
			Need more work on Player first
		*/
		item2.initializeItem();

		Close();
	}
	public void chooseItem3() {
		
		/*
			This should take item3 from above and give/apply to the player
			Need more work on Player first
		*/
		item3.initializeItem();

		Close();
	}


	public void Close(){

		if (ui.activeSelf) {
			ui.SetActive (!ui.activeSelf);
			if (!ui.activeSelf) {
				Time.timeScale = 1f;
			} 

			Destroy(chest);
		}
	}
}
