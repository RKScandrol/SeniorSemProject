using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;

public class ChestMessage : MonoBehaviour
{
    public GameObject ui;
	public Chest c;

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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Open(){
		ui.SetActive (!ui.activeSelf);

		if (ui.activeSelf) {

			/*
				Previously the RawImages were wimply made white
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
			
			HealthPotion hp = new HealthPotion(555, "", "", 5, .5);
													// Original Code
			txtItem1Name.text = "" + item1.getName(); // + c.getItem1().getName();
			txtItem1Des.text = "" + item1.getDescription();
			txtItem2Name.text = "" + item2.getName(); // + c.getItem2().getName();
			txtItem2Des.text = "" + item2.getDescription();
			txtItem3Name.text = "" + item3.getName(); // + c.getItem3().getName();
			txtItem3Des.text = "" + item3.getDescription();


			
			imgItem1.texture = IMG2Sprite.LoadTexture("Assets/Graphics/ItemIcons/HealthPotionIcon.png");
			imgItem2.texture = IMG2Sprite.LoadTexture("Assets/Graphics/ItemIcons/ShockIcon.png");
			imgItem3.texture = IMG2Sprite.LoadTexture("Assets/Graphics/ItemIcons/DefenseBoostIcon.png");
            
			// Time.timeScale = 0f;
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

		this.Close();
	}
	public void chooseItem2() {
		
		/*
			This should take item2 from above and give/apply to the player
			Need more work on Player first
		*/

		this.Close();
	}
	public void chooseItem3() {
		
		/*
			This should take item3 from above and give/apply to the player
			Need more work on Player first
		*/

		this.Close();
	}


	public void Close(){

		if (ui.activeSelf) {
			ui.SetActive (!ui.activeSelf);
			// if (!ui.activeSelf) {
			// 	Time.timeScale = 1f;
			// } 

			GameObject ch = GameObject.Find("chest");
			Destroy(ch);
		}
	}
}
