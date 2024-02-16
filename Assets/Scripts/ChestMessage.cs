using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ChestMessage : MonoBehaviour
{
    public GameObject ui;
	public Chest c;
	public TMP_Text txtItem1;
    public TMP_Text txtItem2;
    public TMP_Text txtItem3;
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

			RawImage rawImage = ui.gameObject.GetComponentInChildren<RawImage>();
			rawImage.color = Color.white;

			GameObject g = GameObject.Find("GameController");
			GameController gc = g.GetComponent<GameController>();
			LootTable lt = gc.getLootTable();
			

			item1 = lt.pickItem();	//Get 1st random Item from LootTable

			do {
				item2 = lt.pickItem();		//Get 2nd random Item from LootTable
			} while (item2.compareItems(item1));	//If item2 has the same ID as item1, loop back to pick new Item

			do {
				item3 = lt.pickItem();		//Get 3rd random Item from LootTable
			} while (item3.compareItems(item1) || item3.compareItems(item2));	//If item3 has the same ID as either item1 or 2, loop back to pick new Item
			
	
													// Original Code
			txtItem1.text = "" + item1.getName(); // + c.getItem1().getName();
			txtItem2.text = "" + item2.getName(); // + c.getItem2().getName();
			txtItem3.text = "" + item3.getName(); // + c.getItem3().getName();

            


			Time.timeScale = 0f;
		} 
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
		ui.SetActive (!ui.activeSelf);
		if (!ui.activeSelf) {
			Time.timeScale = 1f;
		} 
	}
}
