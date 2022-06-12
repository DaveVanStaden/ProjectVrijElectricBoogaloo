using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    public float speed = 6f;
    public float jumpSpeed = 8f;
    public float gravity = -9.81f;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;
    private bool Teleport;
    [SerializeField] private AnimationManager animManager;
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(-horizontal, 0f, -vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; 
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            if (!animManager.Interact)
            {
                animManager.Interact = false;
                animManager.Walk = true;
                animManager.Idle = false;
            }
        }
        else
        {
            if (!animManager.Interact)
            {
                animManager.Interact = false;
                animManager.Walk = false;
                animManager.Idle = true;
            }
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    
}
