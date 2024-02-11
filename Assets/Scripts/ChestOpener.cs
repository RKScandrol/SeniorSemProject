using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    public Chest chest;
    public bool isOpen;
    ChestMessage popupMessage;
    GameObject gameController;
    

    // Start is called before the first frame update
    void Start()
    {
        isOpen = chest.isChestOpen();
        gameController = GameObject.Find("GameController");
		popupMessage = gameController.GetComponent<ChestMessage> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen) {

        }
        if (!isOpen) {
            
        }
    }

    void OnMouseUp() {
        if (!isOpen){
            popupMessage.Open();
            this.isOpen = true;
        }
    }
}
