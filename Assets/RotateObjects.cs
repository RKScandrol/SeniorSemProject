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
                
                //subChild.rotation.z += (-1*z);
                if (subChild.gameObject.tag == "Enemy") {
                    Quaternion q = subChild.rotation;
                    q.z += (-1 * z);
                    subChild.rotation = q;


                    if (z == 1) {
                        Quaternion test = new Quaternion(0,-1*z,0,0);
                        subChild.rotation = test;
                        Debug.Log(subChild.name + " - " + subChild.rotation.z);
                    }
                    
                }

            }


            // Debug.Log(child.name + " - " + z);


        }

    }

}
