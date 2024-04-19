using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSpawnPlayerPositioning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayerPositioning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayerPositioning()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 rot = new Vector3(-15, 0, 0);
        player.position = rot;
    }
}
