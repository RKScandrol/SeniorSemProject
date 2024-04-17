using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloorUISystem : MonoBehaviour
{

    public TMP_Text txtFloor;

    // Start is called before the first frame update
    void Start()
    {
        FloorManager floorManager = GameObject.FindObjectOfType<FloorManager>();
        setFloorText(floorManager.currentFloor + "");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setFloorText(string floorNumber) {
        txtFloor.text = "Floor: " + floorNumber;
    }
}
