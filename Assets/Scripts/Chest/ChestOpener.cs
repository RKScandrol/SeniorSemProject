using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    public Chest chest;
    public bool isOpen;
    ChestMessage popupMessage;
    GameObject gameController;
    public Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        gameController = GameObject.Find("GameController");
		popupMessage = gameController.GetComponent<ChestMessage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen) {

        }
        if (!isOpen) {
            
        }
    }

    // void OnMouseUp() {
    //     if (!isOpen){

    //         animator.Play("ChestOpenAnimation");

    //         popupMessage.Open();
    //         this.isOpen = true;
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {

            // Debug.Log("Trigger");

            if (!isOpen) {
                animator.Play("ChestOpenAnimation");

                popupMessage.Open();
                this.isOpen = true;
            }
        }
    }

}
