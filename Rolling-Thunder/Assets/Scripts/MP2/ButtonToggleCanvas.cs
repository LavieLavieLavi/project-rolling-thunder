using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToggleCanvas : MonoBehaviour
{
    public GameObject canvasToToggle; // Reference to the Canvas you want to toggle

    // This function will be called when the button is clicked
    public void ToggleCanvasVisibility()
    {
        // Check if the canvas is active or not and toggle its visibility
        canvasToToggle.SetActive(!canvasToToggle.activeSelf);
    }
}
