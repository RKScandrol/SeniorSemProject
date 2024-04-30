using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    
    public bool isOpen;
    ChestMessage popupMessage;
    public Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        popupMessage = FindAnyObjectByType<ChestMessage>(FindObjectsInactive.Include);

        isOpen = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && !isOpen) {

            this.isOpen = true;

            animator.Play("ChestOpenAnimation");

            GameObject chest = this.gameObject.transform.parent.gameObject;

            popupMessage.Open(chest);
            
        }
    }

}
