using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstarScanUpdater : MonoBehaviour
{
    bool isUpdated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isUpdated == false)
        {
            updateScan();
            isUpdated = true;
        }
    }

    public void updateScan()
    {
        AstarPath.active.Scan();
    }
}
