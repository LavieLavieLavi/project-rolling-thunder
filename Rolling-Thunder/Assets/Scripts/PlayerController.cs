using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField]private float jumpForce = 10f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.5f;
    [SerializeField] float furnitureDistance = 0.5f;
    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask Furniture;


    public Camera cam;

    public GameObject hiddenObject; // Reference to the hidden game object

    public AudioSource rollSFX;
    public AudioSource jumpSFX;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    
    }



    // Good for handling inputs and animations
    void Update()
    {
        processInputs();
        

        // Check for ESC key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowHiddenObject();
        }
    }

    private void FixedUpdate() // for movement
    {
        Move();
        
    }


    private void processInputs()
    {

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
        
        Vector3 cameraForward = cam.transform.forward;
        cameraForward.y = 0; // Keep the direction horizontal
        cameraForward.Normalize();
        
        Vector3 moveDirection = cameraForward * Input.GetAxis("Vertical") + cam.transform.right * Input.GetAxis("Horizontal");
        moveDirection.Normalize();
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            rollSFX.Play();
        }
        rb.AddForce(moveDirection * moveSpeed  );

        /*if (Input.GetAxis("Horizontal") > 0)
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
        }*/


        #region commented out old scripts
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
        #endregion

    }

    private void Jump()
    {
        #region old Scripts
        /*     Vector3 objectScale = transform.localScale;
             float maxScale = Mathf.Max(objectScale.x, objectScale.y, objectScale.z);

             // Apply jump force taking into account the object's scale
             rb.velocity = new Vector3(rb.velocity.x, jumpForce * maxScale, rb.velocity.z);
        */
        //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        #endregion
        jumpSFX.Play();
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

    }

    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, ground, QueryTriggerInteraction.Ignore);
        
    }

    bool isFurniture()
    {
        return Physics.CheckSphere(groundCheck.position, furnitureDistance, Furniture, QueryTriggerInteraction.Ignore);

    }

    private void ShowHiddenObject()
    {
        // Check if the hidden object is not null
        if (hiddenObject != null)
        {
            // Toggle the visibility based on the current state
            if (hiddenObject.activeSelf)
            {
                // If the object is currently active, hide it and set time scale to 1
                hiddenObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                // If the object is currently inactive, show it and set time scale to 0
                hiddenObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

}
