using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private NavMeshAgent _agent;
    private bool _move = true;
    private float _speed;

    
    void Start()
    {
        _speed = 2.5f;
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _speed;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _move == true)
        {
            _agent.isStopped = false;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                _agent.SetDestination(hit.point);
            }
        }
    }

    public void StopMove()
    {
        _agent.speed = 0;
    }
    public void StartMove()
    {
        _agent.speed = _speed;
    }
}
