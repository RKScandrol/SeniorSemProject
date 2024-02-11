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
			List<Item> items = lt.getList();
			Item i = lt.pickItem();
															// Original Code
			txtItem1.text = "" + lt.pickItem().getName(); // + c.getItem1().getName();
			txtItem2.text = "" + lt.pickItem().getName(); // + c.getItem2().getName();
			txtItem3.text = "" + lt.pickItem().getName(); // + c.getItem3().getName();

            


			Time.timeScale = 0f;
		} 
	}
	public void Close(){
		ui.SetActive (!ui.activeSelf);
		if (!ui.activeSelf) {
			Time.timeScale = 1f;
		} 
	}
}
