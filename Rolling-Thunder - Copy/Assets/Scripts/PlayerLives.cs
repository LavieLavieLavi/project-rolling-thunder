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




    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;
    }

    private void Update()
    {
        dead = false;
        if (transform.position.y < -1f  && !dead) 
        {
            TakeLives(1);
        }
    }

    //taking damage
    void TakeLives(int live)
    {
        currentLives -= live;
        transform.position = respawnPoint.position;
        dead = true;
        Debug.Log("ded");
        //Game over
        if (currentLives <= 0)
        {
            GameOver();
        }
    }


    void GameOver()
    {
        //Implement game over screen here
        Debug.Log("games over");
        Application.Quit();
    }

   

}
