using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public GameObject footstep;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if any movement key is pressed
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            if (!isMoving)
            {
                footsteps();
                isMoving = true;
            }
        }
        else if (isMoving) // Check if all movement keys are released
        {
            StopFootsteps();
            isMoving = false;
        }
    }

    void footsteps()
    {
        footstep.SetActive(true);
    }

    void StopFootsteps()
    {
        footstep.SetActive(false);
    }
}
