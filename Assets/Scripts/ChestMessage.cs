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


			txtItem1.text = "" + c.getItem1().getName();
			txtItem2.text = "" + c.getItem2().getName();
			txtItem3.text = "" + c.getItem3().getName();

            //For testing Purposes:

            // GameObject go = GameObject.Find("LootTable");
            // LootTable lt = go.GetComponent<LootTable>();
            // List<Item> items = lt.getItems();
            // String msg = "";
            // foreach (Item i in items) {
            //     msg += i.getName() + ", ";
            // }
            // txtItem1.text = msg;
            // txtItem2.text = "" + lt.getTotalWeight();


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
