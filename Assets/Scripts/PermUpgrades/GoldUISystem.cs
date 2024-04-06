using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GoldUISystem : MonoBehaviour
{

    public int gold;            //This should be in Player Attributes
    public GameObject txtGoldGameObject;
    private TMP_Text txtGoldUI;

    

    // Start is called before the first frame update
    void Start()
    {

        txtGoldUI = txtGoldGameObject.GetComponent<TextMeshProUGUI>();
        
        setText();

    }

    // Update is called once per frame
    void Update()
    {
        
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
