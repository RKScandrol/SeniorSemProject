using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persist : MonoBehaviour
{
    private static GameObject objInstance;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (objInstance == null)
        {
            objInstance = gameObject;
        }

        else {
            Destroy(gameObject);
        }
    }
}
