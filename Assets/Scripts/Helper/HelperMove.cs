using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HelperMove : MonoBehaviour
{
    private Transform _targetPoint;
    private NavMeshAgent _agent;

    public Transform TargetPoint 
    { 
        get => _targetPoint; 
        set => _targetPoint = value; 
    }

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        Move();
        
    }

    public void Move()
    {
        _agent.SetDestination(TargetPoint.position);
    }
    public void StopMove()
    {
        _agent.isStopped = true;
    }

}
