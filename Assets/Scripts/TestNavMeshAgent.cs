using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestNavMeshAgent : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent agent;
    private Rigidbody rigid;
    private CapsuleCollider _capsuleCollider;
    
    [SerializeField] private Transform savePoint;
    [SerializeField] private Transform startPoint;

    [SerializeField] private bool isJump;
    public bool isPushed;
    private float gravity = 9.81f;
    
    void Start()
    {
        isJump = false;
        isPushed = false;
        agent = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        Gravity();
    }

    void Follow()
    {
        if (!isPushed)
        {
            agent.SetDestination(target.position);
            if ((agent.velocity.sqrMagnitude >= 0.2f * 0.2f) &&
                (agent.remainingDistance < 0.01f))
            {
                MyGameManager.Instance.CurrPlayer += 1;
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_capsuleCollider.CompareTag("Death"))
        {
            Debug.Log("Death");
            agent.enabled = true;
            //gameObject.transform.(savePoint.position.x, savePoint.position.y, savePoint.position.z);
        }
        else if (_capsuleCollider.CompareTag("Level"))
        {
            agent.enabled = true;
            isJump = true;
        }
        else if(!_capsuleCollider.CompareTag("Level"))
        {
            isJump = false;
        }
    }

    private void Gravity()
    {
        if(!isJump)
            rigid.transform.Translate(0, -3f * Time.deltaTime, 0);
    }
    
    private void FixedUpdate()
    {
        FreezeVelocity();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Push"))
        {
            isPushed = true;
            Vector3 reactVec = transform.position - other.transform.position;
            StartCoroutine(Pushed(reactVec));
        }
    }
    void FreezeVelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }
    IEnumerator Pushed(Vector3 reactVec)
    {
        agent.enabled = false;
        
        reactVec = reactVec.normalized;
        reactVec += Vector3.up;

        rigid.AddForce(reactVec * 15, ForceMode.Impulse);
        
        yield return null;
    }
}
