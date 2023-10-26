using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    // Declare game object for showing-hiding buttons
    public GameObject objectToShow;

    // Score threshold to unhide the object
    public int scoreThreshold = 50;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the object is initially hidden
        if (objectToShow != null)
        {
            objectToShow.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the score has reached the threshold to unhide the object
        if (ScoreManager.scoreValue >= scoreThreshold)
        {
            // Unhide the object
            if (objectToShow != null)
            {
                objectToShow.SetActive(true);
            }
        }
    }
}
