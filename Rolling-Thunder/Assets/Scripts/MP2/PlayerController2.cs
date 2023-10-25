using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController2 : MonoBehaviour
{
    public CharacterController _controller;

    [SerializeField]
    float playerSpeed = 6f, gravity = -9.81f, jumpPower;


    [SerializeField]
    float turnSmoothTime = 0.1f;
    float turnVel;


    [SerializeField]
    Transform CameraTransform;
    Vector3 PlayerVelocity;
    public Transform groundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;
    public LayerMask Furniture;

   
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (isGrounded() && PlayerVelocity.y < 0)
        {
            PlayerVelocity.y = -2.5f;
        }

        if (isFurniture() && PlayerVelocity.y < 0)
        {
            PlayerVelocity.y = -2.5f;
        }

        float _horizontal = Input.GetAxisRaw("Horizontal");
        float _vertical = Input.GetAxisRaw("Vertical");


        Vector3 direction = new Vector3(_horizontal, 0, _vertical).normalized;
        

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + CameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVel, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            _controller.Move(moveDirection.normalized * playerSpeed * Time.deltaTime);
        }
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Debug.Log("pressed");
            PlayerVelocity.y = Mathf.Sqrt(jumpPower * -2f * gravity);
        }
        if (Input.GetButtonDown("Jump") && isFurniture())
        {
            Debug.Log("pressed");
            PlayerVelocity.y = Mathf.Sqrt(jumpPower * -2f * gravity);
        }

        PlayerVelocity.y += gravity * Time.deltaTime;
        _controller.Move(PlayerVelocity * Time.deltaTime);

    }

    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, GroundDistance, GroundMask, QueryTriggerInteraction.Ignore);

    }

    bool isFurniture()
    {
        return Physics.CheckSphere(groundCheck.position, GroundMask, Furniture, QueryTriggerInteraction.Ignore);

    }



}