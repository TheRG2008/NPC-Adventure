using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WorkerSlot : MonoBehaviour
{
    [SerializeField] private GameObject _worker;    
    
    public static event Action<Worker> OnWorkerStatsUpdate;

    public GameObject Worker => _worker;

    public void CelectWorker()
    {
        OnWorkerStatsUpdate?.Invoke(_worker.GetComponent<Worker>());
    }
}
