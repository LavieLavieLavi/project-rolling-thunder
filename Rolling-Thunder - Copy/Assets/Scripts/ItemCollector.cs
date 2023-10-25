using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{

    int keyCounter = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Keys"))
        {
            Destroy(other.gameObject);
            keyCounter++;
        }
    }

}
