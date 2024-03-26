using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUISystem : MonoBehaviour
{

    public int gold;            //This should be in Player Attributes
    TMP_Text txtGoldUI;

    private Transform mainCameraTransform;
    private Transform goldUITransform;

    // Start is called before the first frame update
    void Start()
    {

        goldUITransform = this.gameObject.transform;
        txtGoldUI = this.gameObject.GetComponent<TextMeshPro>();
        mainCameraTransform = GameObject.FindGameObjectWithTag("Player").transform.Find("Main Camera").transform;

        positionGoldUI();
        setText();

    }

    // Update is called once per frame
    void Update()
    {
        positionGoldUI();
    }


    public void positionGoldUI() {

        Vector2 newPosition = mainCameraTransform.position;
        newPosition.x += (float)6;
        newPosition.y += (float)4.5;
        goldUITransform.position = newPosition;

    }


    public void setText() {
        txtGoldUI.text = "Gold: " + gold;
    }

    public void increaseGold(int amount) {
        gold += amount;
        setText();
    }

    public void decreaseGold(int amount) {
        gold -= amount;
        setText();
    }

    
}
