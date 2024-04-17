using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    public Chest chest;
    ChestMessage popupMessage;
    public Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        //Get ChestMeassage Popup
        popupMessage = FindAnyObjectByType<ChestMessage>(FindObjectsInactive.Include);
        
    }

    

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            //Play ChestOpen Animation
            animator.Play("ChestOpenAnimation");
            //Get Parent GameObject
            GameObject chest = this.gameObject.transform.parent.gameObject;
            //Open the ChestMessage Popup, passing a reference to parent Gameobject so it can be deleted
            popupMessage.Open(chest);
            
        }
    }

}
