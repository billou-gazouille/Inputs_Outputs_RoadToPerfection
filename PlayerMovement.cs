using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    [Range(1f, 20.0f)]
    public float speed;
    [Range(-50f, -1f)]
    public float gravity;
    public float jumpHeight;

    public float acceleration = 10;
    private float currentSpeed;
    private Vector3 lastMoveDirection;

    public Transform groundCheck;
    public LayerMask groundMask;

    public Vector3 velocity;
    bool isGrounded;

    public bool isSprung = false;

    private void Start()
    {
        lastMoveDirection = transform.forward;
    }

    void Update()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, controller.transform.localScale.y * 1.2f, groundMask);
        isGrounded = Physics.CheckSphere(groundCheck.position, controller.transform.localScale.y / 2f + 0.1f, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float x = (Keyboard.current.aKey.isPressed ? -1f : 0f) + (Keyboard.current.dKey.isPressed ? 1f : 0f);
        float z = (Keyboard.current.sKey.isPressed ? -1f : 0f) + (Keyboard.current.wKey.isPressed ? 1f : 0f);

        Vector3 move = (transform.right * x + transform.forward * z).normalized;

        if (!isSprung)
        {
            if (move != Vector3.zero)
                lastMoveDirection = move;

            if (move == Vector3.zero)
                currentSpeed = Mathf.Max(currentSpeed - acceleration * Time.deltaTime, 0f);
            else
                currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, speed);
        }

        else
        {
            lastMoveDirection = new Vector3(velocity.x, 0f, velocity.z).normalized;
            currentSpeed = new Vector3(velocity.x, 0f, velocity.z).magnitude;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        velocity = new Vector3(0f, velocity.y, 0f) + lastMoveDirection * currentSpeed;
        controller.Move(velocity * Time.deltaTime);
    }
}
