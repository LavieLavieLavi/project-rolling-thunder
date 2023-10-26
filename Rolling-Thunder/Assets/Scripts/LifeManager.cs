using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    private int lifeCount;
    Text life;

    // Start is called before the first frame update
    void Start()
    {
        life = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the lives count in Update
        lifeCount = PlayerLives.currentLives;
        life.text = lifeCount.ToString();
    }
}
