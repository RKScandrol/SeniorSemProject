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
        
        //Number of rooms
        int childCount = gameObject.transform.childCount;

        for (int i = 0; i < childCount ; i++) {

            //The room
            Transform child = gameObject.transform.GetChild(i);

            //Rotation Degree of Room
            float z = child.rotation.z;

            //Number of children in room(enemies and chest)
            int subChildCount = child.childCount;

            for(int j = 0; j < subChildCount ; j++) {


                Transform subChild = child.GetChild(j);
                if(subChild.gameObject.tag == "Enemy")
                {
                    //Quaternion vec = subChild.rotation;
                    //vec.z += (-1 * z);
                    //subChild.rotation = vec;


                    //if(z == 1)
                    //{
                        Quaternion rot = new Quaternion(0, -1 * z, 0, 0);
                        subChild.rotation = rot;
                    //}
                    

                }
                if(subChild.gameObject.tag == "Chest")
                {
                    Quaternion rot = new Quaternion(0, -1 * z, 0, 0);
                    subChild.rotation = rot;
                    
                }
               

            }


        }

        updateAStarPath();

    }

    void updateAStarPath()
    {
        AstarPath.active.Scan();
    }

}
