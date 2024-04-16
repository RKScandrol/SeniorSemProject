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

	

	public void Open(GameObject chest) {
		
		//Save refernece to Chest that was Opened
		this.chest = chest;
		//Show Popup
		ui.SetActive(true);

		
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
		
		
		//Set text from Items
		txtItem1Name.text = "" + item1.getName(); 
		txtItem1Des.text = "" + item1.getDescription();
		txtItem2Name.text = "" + item2.getName(); 
		txtItem2Des.text = "" + item2.getDescription();
		txtItem3Name.text = "" + item3.getName(); 
		txtItem3Des.text = "" + item3.getDescription();

		//Set Images from Items
		imgItem1.texture = IMG2Sprite.LoadTexture(item1.getIconPath());
		imgItem2.texture = IMG2Sprite.LoadTexture(item2.getIconPath());
		imgItem3.texture = IMG2Sprite.LoadTexture(item3.getIconPath());
		
		//Freeze Time
		Time.timeScale = 0f;
		
	}

	
	public void chooseItem1() {
		
		/*
			Initializes 1st Item
		*/
		item1.initializeItem();

		Close();
	}
	public void chooseItem2() {
		
		/*
			Initializes 2nd Item
		*/
		item2.initializeItem();

		Close();
	}
	public void chooseItem3() {
		
		/*
			Initializes 3rd Item
		*/
		item3.initializeItem();

		Close();
	}


	public void Close(){

		if (ui.activeSelf) {
			//Hide Popup
			ui.SetActive(false);
			//Unfreeae Time
			Time.timeScale = 1f;

			//Destroy Opened Chest GameObject
			Destroy(chest);
		}
	}
}
