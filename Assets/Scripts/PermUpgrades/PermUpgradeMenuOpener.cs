using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermUpgradeMenuOpener : MonoBehaviour
{
    public GameObject permUpgradeMenu;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            permUpgradeMenu.SetActive(true);
            // Debug.Log("Entered");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            permUpgradeMenu.transform.parent.GetComponent<PermUpgradeSystem>().exitMenu();
            // Debug.Log("Exited");
        }
    }
}
