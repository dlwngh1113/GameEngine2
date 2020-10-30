using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private float hAxis;
    private float vAxis;

    private Vector3 moveVec;
    
    private Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        GetInput();
        Move();
        Turn();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
    }
    
    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;
    }
    
    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }
}
