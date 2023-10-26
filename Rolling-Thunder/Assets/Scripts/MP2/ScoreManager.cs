using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;

    // Define the score thresholds for showing the next level canvas
    public List<int> showCanvasThresholds = new List<int> { 100, 200, 300 };

    // Reference to the canvas you want to show
    public List<GameObject> nextLevelCanvases = new List<GameObject>();

    private int currentLevel = 0;

    private void Start()
    {
        score = GetComponent<Text>();
        // Ensure all canvases are initially hidden
        foreach (var canvas in nextLevelCanvases)
        {
            canvas.SetActive(false);
        }

        Time.timeScale = 1;

        if (scoreValue >= 13)
        {
            scoreValue = 0;
        }
    }

    private void Update()
    {
        score.text = scoreValue.ToString() + "/13";

        // Check if the score has reached the threshold to show the canvas
        if (scoreValue >= showCanvasThresholds[currentLevel])
        {
            // Show the canvas for the current level
            nextLevelCanvases[currentLevel].SetActive(true);

            Time.timeScale = 1;

            // Move to the next level
            currentLevel++;

            // Check if there are no more levels, reset the current level
            if (currentLevel >= nextLevelCanvases.Count)
            {
                currentLevel = 0;
            }
        }
    }
}
