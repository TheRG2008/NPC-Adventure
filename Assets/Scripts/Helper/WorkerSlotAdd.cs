using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class WorkerSlotAdd : MonoBehaviour
{
    [SerializeField] private GameObject _checkMark;
    private Worker _worker;
    public bool IsOpen = false;
    public bool IsChoise = false;
    private PanelsManager _panelsManager;
    public int Index;

    public static event Action<Worker> OnWorkerAddStatsUpdate;
    public static event Action<WorkerSlotAdd> OnWorkerIndexUpdate;

    public Worker Worker => _worker;

    private void Start()
    {
        _panelsManager = FindObjectOfType<PanelsManager>();
    }
    public void CelectWorker()
    {
        OnWorkerAddStatsUpdate?.Invoke(_worker);
        OnWorkerIndexUpdate?.Invoke(this);
        _panelsManager.Show(Panels.WorkerStats);
    }

    public void ShowWorkerImg(Sprite img)
    {
        GetComponent<Image>().sprite = img;
    }

    public void ShowCheckMark()
    {
        _checkMark.SetActive(true);
        IsChoise = true;
    }

    public void HideCheckMark()
    {
        _checkMark.SetActive(false);
        IsChoise = false;
    }

    public void AddWorkerToSlot(Worker worker)
    {
        _worker = worker;
    }
}
