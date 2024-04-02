using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //Used to specify target scene
    public int sceneBuildIndex;
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
        Time.timeScale = 1;
        if (GameObject.FindGameObjectWithTag("FloorManager") != null)
        {
            GameObject.FindGameObjectWithTag("FloorManager").GetComponent<FloorManager>().nextFloor();
        }
        SceneManager.LoadSceneAsync(sceneBuildIndex, LoadSceneMode.Single);
    }
    
}
