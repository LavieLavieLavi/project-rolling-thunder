using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;

    // Define the score threshold for showing the next level canvas
    public int showCanvasThreshold = 100;

    // Reference to the canvas you want to show
    public GameObject nextLevelCanvas;

    private void Start()
    {
        score = GetComponent<Text>();
        // Ensure the canvas is initially hidden
        nextLevelCanvas.SetActive(false);
        Time.timeScale = 1;

        if (scoreValue >= 160)
        {
            scoreValue = 0;
        }
    }

    private void Update()
    {
        score.text = "Score: " + scoreValue.ToString();

        // Check if the score has reached the threshold to show the canvas
        if (scoreValue >= showCanvasThreshold)
        {
            // Show the canvas
            nextLevelCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // This method is called when the button in the canvas is pressed
    /*public void LoadNextLevel()
    {
        // Here you can place the code to load the next level
        // For example, you can load the next scene:
        UnityEngine.SceneManagement.SceneManager.LoadScene("MP3_Level2");
    }*/
}
