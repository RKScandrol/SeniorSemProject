using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestExit : MonoBehaviour
{


    ChestMessage popupMessage;
    GameObject gameController;

    
    // Start is called before the first frame update
    void Start()
    {
        // gameController = GameObject.Find("GameController");
        // popupMessage = gameController.GetComponent<ChestMessage>();

        popupMessage = FindAnyObjectByType<ChestMessage>(FindObjectsInactive.Include);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            
            popupMessage.Close();
            
        }
    }
}
