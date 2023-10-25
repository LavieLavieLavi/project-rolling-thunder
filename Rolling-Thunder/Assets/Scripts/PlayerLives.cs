using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLives : MonoBehaviour
{
    public int maxLives = 3;

    public int currentLives;

    bool dead = false;
   
    public Transform respawnPoint;

    [SerializeField]private float fallHeight = 5f;

   


    private float initialY;


    // Start is called before the first frame update

    private void Awake()
    {
        
        Respawn();
    }
    void Start()
    {
        currentLives = maxLives;
        initialY = transform.position.y;
    }

    private void Update()
    {
        float verticalDistance = initialY - transform.position.y;

        dead = false;
        if (verticalDistance >= fallHeight && !dead)
        {
            Debug.Log("Dead - Fell from a great height!");
            TakeLives(1); // Instantly die
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        ProcessingCollisions(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ProcessingCollisions(collision.gameObject); 
    }




    //taking damage
    public void TakeLives(int live)
    {
        currentLives -= live;
        dead = true;
        Debug.Log("Took a live");

        //Game over
        if (currentLives <= 0)
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
      
    }

    void Respawn()
    {


        Debug.Log("Respawned");
        transform.position = respawnPoint.position;
        initialY = transform.position.y;
    }

    void ProcessingCollisions(GameObject collider)
    {
        if (collider.CompareTag("Damage"))
        {
            TakeLives(1);
        }
    }
   
}
