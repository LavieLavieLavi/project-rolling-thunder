using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdd : MonoBehaviour
{
    // Define the score value to add when the player collides
    public int scoreToAdd = 1;

    public AudioSource collectSFX;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Add the specified score
            ScoreManager.scoreValue += scoreToAdd;
            collectSFX.Play();
            // Optional: Destroy the GameObject after collision (if needed)
            Destroy(gameObject);
        }
    }
}
