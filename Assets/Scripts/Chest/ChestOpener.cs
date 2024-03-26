using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    public Chest chest;
    public bool isOpen;
    ChestMessage popupMessage;
    // GameObject gameController;
    public Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        // gameController = GameObject.Find("GameController");
        // popupMessage = gameController.GetComponent<ChestMessage>();
        
        // popupMessage = GameObject.Find("ChestMessage").GetComponent<ChestMessage>();


        popupMessage = FindAnyObjectByType<ChestMessage>(FindObjectsInactive.Include);

        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnMouseUp() {
    //     if (!isOpen){

    //         animator.Play("ChestOpenAnimation");

    //         popupMessage.Open();
    //         this.isOpen = true;
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && !isOpen) {

            // Debug.Log(isOpen);
            this.isOpen = true;
            // Debug.Log(isOpen);

            animator.Play("ChestOpenAnimation");

            popupMessage.Open();
            
        }
    }

    // private void OnTriggerExit2D(Collider2D other) {
    //     if (other.tag == "Player" && isOpen) {
            
    //         // Debug.Log(isOpen);
    //         popupMessage.Close();
            
    //     }
    // }

}
