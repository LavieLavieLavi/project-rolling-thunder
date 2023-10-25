using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public GameObject canvasToToggle; // Reference to the Canvas you want to toggle

    // Public variable to hold the next scene name
    public string nextSceneName;

    private void Start()
    {
        // Ensure the canvas is initially hidden    
        canvasToToggle.SetActive(false);
    }

    public void ToggleCanvasVisibility()
    {
        // Toggle the visibility of the canvas
        canvasToToggle.SetActive(!canvasToToggle.activeSelf);
    }

    public void LoadNextScene()
    {
        // Load the next scene using the scene name from the public variable
        SceneManager.LoadScene(nextSceneName);
    }
}
