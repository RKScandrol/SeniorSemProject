using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class XRayStats : MonoBehaviour
{

    private GameObject enemy;
    private GameObject xray;
    private TMP_Text txtStats;
    private EnemyAttributes enemyAttributes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void initializeXRayStats() {
        enemy = this.gameObject.GetComponent<Transform>().parent.gameObject;
        xray = this.gameObject;
        enemyAttributes = enemy.GetComponent<EnemyAttributes>();
        txtStats = xray.GetComponent<TextMeshPro>();

        setText();

    }


    public void setText() {
        txtStats.text = "Attack: " + enemyAttributes.getAttack() + 
                        "\nDefense: " + enemyAttributes.getDefense();
    }

    public void showTxtStats() {
        txtStats.enabled = true;
    }

    public void hideTxtStats() {
        txtStats.enabled = false;
    }
}
