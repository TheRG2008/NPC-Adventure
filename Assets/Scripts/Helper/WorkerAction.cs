using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerAction : MonoBehaviour
{
    private ResourceForTest _collectResource;
    private int _curentCountResource = 0;
    private Worker _worker;
    private Transform _targetPoint;
    private bool _isActive;

    public Transform TargetPoint => _targetPoint;
    public bool IsActive => _isActive;

    private void Awake()
    {
        _isActive = false;
        _worker = gameObject.GetComponent<Worker>();

    }
    private void Die()
    {
        Destroy(gameObject, 2);
    }

    public void AddTargetPoint(Transform targetPoint)
    {
        _targetPoint = targetPoint;
        _isActive = true;
    }

    public void RemoveTargetPoint()
    {
        _targetPoint = null;
        _isActive = false;
    }

    private void CollectResourse()
    {
        //GroundCell cellWithResorce = _targetPointForCollect.gameObject.GetComponent<GroundCell>();        
        //_collectResource = cellWithResorce.GiveResource(_worker.MaxCountResorceCollect, out _curentCountResource);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            gameObject.GetComponent<HelperMove>().StopMove();
            return;
        }
        //if (other.gameObject == _targetPointForCollect.gameObject)
        //{
        //    gameObject.GetComponent<HelperMove>().StopMove();
        //    CollectResourse();
        //}
    }
}
