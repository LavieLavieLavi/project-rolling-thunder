using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody rb;

    // Customize the force values in the Unity Inspector
    public float forceX = 0f;
    public float forceY = 0f;
    public float forceZ = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // You can optionally add an initial force here if needed
        // rb.AddForce(forceX, forceY, forceZ);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(forceX, forceY, forceZ * Time.deltaTime);
    }
}
