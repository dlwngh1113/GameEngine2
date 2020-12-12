using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestNavMeshAgent : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        if((agent.velocity.sqrMagnitude >= 0.2f * 0.2f) && 
            (agent.remainingDistance < 0.5f))
        {
            MyGameManager.Instance.CurrPlayer += 1;
            this.gameObject.SetActive(false);
        }
    }
}
