using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdd : MonoBehaviour
{
    // Define the score value to add when the player collides
    public int scoreToAdd = 10;

    // This function is called when the player collides with the GameObject
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is tagged as "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Add the specified score
            ScoreManager.scoreValue += scoreToAdd;

            // Optional: Destroy the GameObject after collision (if needed)
            Destroy(gameObject);
        }
    }
}
