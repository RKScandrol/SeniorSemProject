using TMPro;
using UnityEngine;

public class XRayStats : MonoBehaviour
{

    private GameObject enemy;
    public TMP_Text txtAttack;
    public UnityEngine.UI.Image imgAttack;
    public TMP_Text txtDefense;
    public UnityEngine.UI.Image imgDefense;
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
        enemyAttributes = enemy.GetComponent<EnemyAttributes>();
        
        setText();
        hideTxtStats();
        
    }


    public void setText() {
        txtAttack.text = "" + enemyAttributes.attack;
        txtDefense.text = "" + enemyAttributes.defense;
    }

    public void showTxtStats() {
        txtAttack.enabled = true;
        imgAttack.enabled = true;
        txtDefense.enabled = true;
        imgDefense.enabled = true;
    }

    public void hideTxtStats() {
        txtAttack.enabled = false;
        imgAttack.enabled = false;
        txtDefense.enabled = false;
        imgDefense.enabled = false;
    }
}
