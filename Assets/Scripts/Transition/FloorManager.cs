using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    private int baseFloor = 1;
    public int currentFloor;

    void Start()
    {
        currentFloor = baseFloor;
    }
    
    public void nextFloor()
    {
        currentFloor++;
        Debug.Log(currentFloor);
    }
}
