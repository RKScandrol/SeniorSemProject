using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //Used to specify target scenes
    public int dungeonIndex;
    public int bedroomIndex;
    public Animator animator;
    public BoxCollider2D boxCollider2D;

    private void OnTriggerEnter2D(Collider2D other) {
        //Player entered trigger point, initiate transition to next scene
        if (other.tag == "Player") {
            Time.timeScale = 0;
            animator.SetTrigger("FadeOut");
        }
    }

    public void OnFadeComplete() {
        if (GameObject.FindGameObjectWithTag("FloorManager") != null)
        {
            GameObject.FindGameObjectWithTag("FloorManager").GetComponent<FloorManager>().nextFloor();
        }
        SceneManager.LoadSceneAsync(dungeonIndex, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void OnDeathComplete() {
        SceneManager.LoadSceneAsync(bedroomIndex, LoadSceneMode.Single);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("FloorManager"));
        Time.timeScale = 1;
    }
    
}
