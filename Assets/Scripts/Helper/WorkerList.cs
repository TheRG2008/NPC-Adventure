using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerList : MonoBehaviour
{
    private Player _player;
    private PanelsManager _panelsManager;
    private List<GameObject> _workers;
    private List<Transform> _targets;
    public int Size => _workers.Count;
    

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _panelsManager = FindObjectOfType<PanelsManager>();
        _workers = new List<GameObject>();
        _targets = new List<Transform>();
    }
    public Worker GetWorkerScript(int index)
    {
        if(_workers[index] == null)
        {
            return null;
        }
        return _workers[index].GetComponent<Worker>();
    }

    public GameObject GetWorkerGameObject(int index)
    {
        if (_workers[index] == null)
        {
            return null;
        }
        return _workers[index];
    }

    public void AddWorker(GameObject worker)
    {
        if(_player.Gold < worker.GetComponent<Worker>().GoldForRent)
        {            
            _panelsManager.Show(Panels.NotEnoughGold);
            return;
        }
        if(_workers.Count >= _player.MaxWorkerCount)
        {
            _panelsManager.Show(Panels.EnoughSpacePanel);
            return;
        }
        _player.Gold -= worker.GetComponent<Worker>().GoldForRent;
        _workers.Add(worker);
        Debug.Log("Рабочий нанят");
    }

    public void RemoveWorker(int index)
    {
        _workers.RemoveAt(index);
    }

    public void AddTarget(Transform transform, int index)
    {
        _targets.Add(transform);
        _workers[index].GetComponent<Worker>().TargetIndex = _targets.Count - 1;
    }

    public void GetTarget(Transform transform, int index)
    {
        _workers[index].GetComponent<WorkerAction>().AddTargetPoint(transform);
        
    }
    public void RemoveTarget(int index)
    {
        _workers[index].GetComponent<WorkerAction>().RemoveTargetPoint();        
    }
}
