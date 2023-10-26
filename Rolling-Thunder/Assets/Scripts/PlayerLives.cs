using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


public class PlayerLives : MonoBehaviour
{
    public static int maxLives = 3;

    public static int currentLives;

    //bool dead = false;
   
    public Transform respawnPoint;

   // [SerializeField]private float fallHeight = 5f;

    public GameObject gameOverObject; // Reference to the "Game Over" GameObject in the Inspector

    private float initialY;

    public AudioSource dieSFX;
    public AudioSource gameoverSFX;

    private bool isProcessingCollision = false;


    // Start is called before the first frame update


    void Start()
    {
        currentLives = maxLives;
        //initialY = transform.position.y;
    }

    private void Update()
    {
     /*   float verticalDistance = initialY - transform.position.y;

        dead = false;
        if (verticalDistance >= fallHeight && !dead)
        {
            Debug.Log("Dead - Fell from a great height!");
            TakeLives(1); // Instantly die
        }*/

    }

  

    //taking damage
    public void TakeLives(int live)
    {
      
        currentLives -= live;
        Debug.Log("Took a live");

        //Game over
        if (currentLives < 0)
        {
            GameOver();
        }
        else
        {
            Respawn();
        }
    }


    void GameOver()
    {
        //Implement game over screen here
        Debug.Log("Game over");
        gameoverSFX.Play();
        // Show the "Game Over" GameObject when the player dies
        gameOverObject.SetActive(true);
        Time.timeScale = 0;
    }

    void Respawn()
    {

       // dead = false;
        Debug.Log("Respawned");
        transform.position = respawnPoint.position;
        initialY = transform.position.y;
    }





    private void OnCollisionEnter(Collision collision)
    {
        if (!isProcessingCollision)
        {
            isProcessingCollision = true;
            ProcessingCollisions(collision.collider);
            StartCoroutine(ResetCollisionFlag());
        }
    }

    IEnumerator ResetCollisionFlag()
    {
        // Wait for the end of the frame to reset the flag
        yield return new WaitForEndOfFrame();
        isProcessingCollision = false;
    }

    void ProcessingCollisions(Collider collider)
    {
        if (collider.CompareTag("Damage"))
        {
            dieSFX.Play();
            TakeLives(1);
        }
    }

}
