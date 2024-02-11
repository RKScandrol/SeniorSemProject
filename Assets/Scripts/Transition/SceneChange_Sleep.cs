using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //Used to specify target scene
    public int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D other) {
        //Player entered trigger point, transition to next scene
        if (other.tag == "Player") {
            SceneManager.LoadSceneAsync(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
    
}
