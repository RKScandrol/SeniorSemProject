using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GoldUISystem : MonoBehaviour
{


    public GameObject txtGoldGameObject;
    private TMP_Text txtGoldUI;
    public bool isInit;

    

    // Start is called before the first frame update
    void Start()
    {
        isInit = false;

        txtGoldUI = txtGoldGameObject.GetComponent<TextMeshProUGUI>();

        PlayerAttributes playerAttributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();
        if (playerAttributes != null) {
            setText(playerAttributes.getGold());
        }

        isInit = true;
    }


    public void setText(int gold) {
        txtGoldUI.text = "Gold: " + gold;
    }
    
}
