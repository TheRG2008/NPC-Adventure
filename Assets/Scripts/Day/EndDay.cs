using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDay : MonoBehaviour
{
    [SerializeField] Transform _helperStartPosition;
    private WorkerList _workerList;

    private void Start()
    {
        _workerList = FindObjectOfType<WorkerList>();
    }

    public void EndTheDay()
    {
        for (int i = 0; i < _workerList.Size; i++)
        {
            if (_workerList.GetWorkerScript(i).GetComponent<WorkerAction>().IsActive == true)
            {
                Instantiate(_workerList.GetWorkerGameObject(i), _helperStartPosition);
            }
        }
    }

}
