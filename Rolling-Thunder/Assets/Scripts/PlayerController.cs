using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField]private float jumpForce = 10f;
    private float xrotation;
    private float yrotation;


    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.5f;
    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask Furniture;


    private Transform followTarget;
    [SerializeField] Transform cameraFollowTarget;


    public PlayerInputManager input;
    private CharacterController controller;
    [SerializeField] GameObject mainCam;

    private void Awake()
    {

        rb = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInputManager>();
        controller = GetComponent<CharacterController>();
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
    private void LateUpdate()
    {
        CameraRotate();
    }

    private void processInputs()
    {

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Debug.Log("space");
           
            Jump();
   
        }

        if (Input.GetButtonDown("Jump") && isFurniture())
        {
            Debug.Log("space");
            Jump();

        }
    }

    private void Move()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(Vector3.right * moveSpeed);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(-Vector3.right * moveSpeed);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(Vector3.forward * moveSpeed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddForce(-Vector3.forward * moveSpeed);
        }



        /*      float speed = 0;

              Vector3 inputDir = new Vector3(input.move.x, 0, input.move.y);
              float targetRot = 0;

              if (input.move != Vector2.zero)
              {
                  speed = moveSpeed;
                  targetRot = Quaternion.LookRotation(inputDir).eulerAngles.y + mainCam.transform.rotation.eulerAngles.y;
                  Quaternion rotation = Quaternion.Euler(0, targetRot, 0);
                  transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 20 * Time.deltaTime);
              }
              Vector3 targetDirection = Quaternion.Euler(0,targetRot,0) * Vector3.forward;*/
        // controller.Move(inputDir * moveSpeed * Time.deltaTime);
        // float scaleFactor = transform.localScale.x;

        /* //THIS IS THE CODE BEFORE U UPDATED THE BALL MOVEMENT
         Vector3 targetDir = new Vector3(input.move.x, 0, input.move.y).normalized;
         Vector3 objectScale = transform.localScale;
         float maxScale = Mathf.Max(objectScale.x, objectScale.y, objectScale.z);
         rb.AddForce(targetDir * moveSpeed * maxScale);*/



        //rb.Move(input.move * moveSpeed * Time.deltaTime, Quaternion.identity);


        /*  Quaternion targetRotate = Quaternion.LookRotation(targetDir);
          if (input.move != Vector2.zero)
          {
              transform.rotation = Quaternion.Slerp(transform.rotation, targetRotate, 20 * Time.deltaTime)
          }*/
        //rb.AddForce(new Vector3(xinput, 0f , zinput) * moveSpeed);
    }

    private void Jump()
    {
   /*     Vector3 objectScale = transform.localScale;
        float maxScale = Mathf.Max(objectScale.x, objectScale.y, objectScale.z);

        // Apply jump force taking into account the object's scale
        rb.velocity = new Vector3(rb.velocity.x, jumpForce * maxScale, rb.velocity.z);
*/
        rb.velocity = new Vector3 (rb.velocity.x, jumpForce, rb.velocity.z);
        //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);


    }

    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, ground, QueryTriggerInteraction.Ignore);
        
    }

    bool isFurniture()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, Furniture, QueryTriggerInteraction.Ignore);

    }


    void CameraRotate()
    {
        xrotation += input.look.y;
        yrotation += input.look.x;
        xrotation = Mathf.Clamp(xrotation, -30, 70);

        Quaternion rotation = Quaternion.Euler(xrotation, yrotation, 0);

        cameraFollowTarget.rotation = rotation;
    }


}
