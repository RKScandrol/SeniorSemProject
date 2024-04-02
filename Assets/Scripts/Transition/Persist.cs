using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Persist : MonoBehaviour
{
    [SerializeField]
    private String tagString;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tagString);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
