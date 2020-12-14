using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float hAxis;
    private float vAxis;

    private bool jDown;
    private bool isJump;
    private bool isGrounded;
    private bool isDead;
    
    [SerializeField] private float speed;
    private float turnSmoothTime;
    [SerializeField] private float jumpHeight;
    private float turnSmoothVelocity;
    [SerializeField] private float gravity = -9.81f;
    private float groundDistance = 0.4f;

    [SerializeField] private LayerMask groundMask;
    [SerializeField] private LayerMask deadMask;
    
    private Vector3 velocity;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform savePoint;
    [SerializeField] private Transform startPoint;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform cam;

    private void Update()
    {
        GetInput();
        Move();
        Gravity();
        Jump();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        jDown = Input.GetButtonDown("Jump");
    }
    
    void Move()
    {
        Vector3 direction = new Vector3(hAxis, 0, vAxis).normalized;
        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        if (jDown && isGrounded)
        {
            //Debug.Log("Jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Death"))
        {
            controller.gameObject.transform.position =
                new Vector3(savePoint.position.x, savePoint.position.y, savePoint.position.z);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            MySceneManager.Instance.LoadScene();
        } 
        else if (other.gameObject.CompareTag("Save"))
        {
            savePoint.position = new Vector3(other.transform.position.x, other.transform.position.y,
                other.transform.position.z);
        }
    }
}
