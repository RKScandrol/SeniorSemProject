using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    private static GameObject playerInstance;
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (playerInstance == null)
        {
            playerInstance = gameObject;
        }

        else {
            Destroy(gameObject);
        }
    }
}
