using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkersCurrent : MonoBehaviour
{
    [SerializeField] private GameObject[] _workerAddSlots;
    private WorkerList _workerList;

    private void Awake()
    {
        _workerList = FindObjectOfType<WorkerList>();
    }
    public void WorkerSlotUpdate()
    {
        if (_workerList.Size == 0)
        {
            HideAllSlots();
            return;
        }

        HideAllSlots();
        for (int i = 0; i < _workerList.Size; i++)
        {
            WorkerSlotAdd workerAddSlot = _workerAddSlots[i].GetComponent<WorkerSlotAdd>();
            Worker worker = _workerList.GetWorker(i); 
            _workerAddSlots[i].SetActive(true);
            workerAddSlot.ShowWorkerImg(worker.Img);
            workerAddSlot.AddWorkerToSlot(worker);
            workerAddSlot.IsOpen = true;
            workerAddSlot.Index = i;
            if(workerAddSlot.IsChoise == true)
            {
                workerAddSlot.ShowCheckMark();
            }
            else
            {
                workerAddSlot.HideCheckMark();
            }
        }

        HideNotUsingWorkerSlot();
    }

    
    private void HideAllSlots()
    {
        for (int i = 0; i < _workerAddSlots.Length; i++)
        {
            _workerAddSlots[i].GetComponent<WorkerSlotAdd>().IsOpen = false;
            _workerAddSlots[i].SetActive(false);
        }
    }
    public void HideNotUsingWorkerSlot()
    {
        for (int i = 0; i < _workerAddSlots.Length; i++)
        {
            if (_workerAddSlots[i].GetComponent<WorkerSlotAdd>().IsOpen == false)
            {
                _workerAddSlots[i].SetActive(false);
            }
        }
    }

    public WorkerSlotAdd GetSlot(int index)
    {
        return _workerAddSlots[index].GetComponent<WorkerSlotAdd>();
        
    }

    
}
