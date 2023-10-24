using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField]private float jumpForce = 100f;
    private float xinput;
    private float zinput;


    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.5f;
    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask Furniture;


    private Transform followTarget;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        followTarget = new GameObject("PlayerFollowTarget").transform;
    }



    // Good for handling inputs and animations
    void Update()
    {
        processInputs();
    }

    private void FixedUpdate() // for movement
    {
        Move();
    }

    private void processInputs()
    {
        xinput = Input.GetAxis("Horizontal");
        zinput = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded() )
        {
           
            Jump();
   
        }

        if (Input.GetButtonDown("Jump") && isFurniture())
        {
            Jump();

        }
    }

    private void Move()
    {
        
        rb.AddForce(new Vector3(xinput, 0f , zinput) * moveSpeed);
    }

    private void Jump()
    {
        rb.velocity = new Vector3 (rb.velocity.x, jumpForce, rb.velocity.z);



    }

    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, ground, QueryTriggerInteraction.Ignore);
        
    }

    bool isFurniture()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, Furniture, QueryTriggerInteraction.Ignore);

    }





}
