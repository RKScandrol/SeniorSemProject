using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PermUpgradeSystem : MonoBehaviour
{

    public GameObject permUpgradeMenu;
    public TMP_Text txtHealthDesc;
    public TMP_Text txtAttackDesc;
    public TMP_Text txtDefenseDesc;


    // Start is called before the first frame update
    void Start()
    {
        
        setHealthDescription();
        setAttackDescription();
        setDefenseDescription();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setHealthDescription() {
        txtHealthDesc.text = txtHealthDesc.text + "Current Player Health: h1" 
            + "\nIncrease Percent: x"
            + "\nNew Player Health: h2";
    }

    public void setAttackDescription() {
        txtAttackDesc.text = txtAttackDesc.text + "Current Player Attack: a1" 
            + "\nIncrease Percent: y"
            + "\nNew Player Attack: a2";
    }

    public void setDefenseDescription() {
        txtDefenseDesc.text = txtDefenseDesc.text + "Current Player Defense: d1" 
            + "\nIncrease Defense: z"
            + "\nNew Player Defense: d2";
    }



    
}
