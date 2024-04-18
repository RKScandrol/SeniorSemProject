using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RotateGameObjects() {
        
        int childCount = gameObject.transform.childCount;

        for (int i = 0; i < childCount ; i++) {

            Transform child = gameObject.transform.GetChild(i);

            float z = child.rotation.z;

            int subChildCount = child.childCount;

            for(int j = 0; j < subChildCount ; j++) {

                Transform subChild = child.GetChild(j);

                subChild.rotation.z += (-1*z);

            }


        }

    }

}
