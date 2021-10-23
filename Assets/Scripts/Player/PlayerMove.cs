using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
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
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.GetComponent<Resource>() ||
                    hit.collider.GetComponent<Enemy>())
                {
                    return;
                }
                _agent.SetDestination(hit.point);
            }
        }
    }
   
}
