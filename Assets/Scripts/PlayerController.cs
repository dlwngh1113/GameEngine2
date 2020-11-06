using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float hAxis;
    private float vAxis;
    
    [SerializeField] private float speed;
    [SerializeField] private float turnSmoothTime;
    private float turnSmoothVelocity;
    
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform cam;

    private void Awake()
    {
        
    }

    private void Update()
    {
        GetInput();
        Move();
        Jump();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
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

    void Jump()
    {
        
    }
}
