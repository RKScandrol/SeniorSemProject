using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstarScanUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        updateScan();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScan()
    {
        AstarPath.active.Scan();
    }
}
