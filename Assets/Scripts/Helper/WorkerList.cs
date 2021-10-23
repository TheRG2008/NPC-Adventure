using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerList : MonoBehaviour
{
    private Player _player;
    private PanelsManager _panelsManager;
    private List<GameObject> _workers;
    public int Size => _workers.Count;
    

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _panelsManager = FindObjectOfType<PanelsManager>();
        _workers = new List<GameObject>(6);
    }
    public Worker GetWorker(int index)
    {
        if(_workers[index] == null)
        {
            return null;
        }
        return _workers[index].GetComponent<Worker>();
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

    public void GetTarget(Transform transform, int index)
    {
        _workers[index].GetComponent<Worker>().PositionForCollectResource = transform;
        _workers[index].GetComponent<Worker>().IsActive = true;
    }
    public void RemoveTarget(int index)
    {
        _workers[index].GetComponent<Worker>().PositionForCollectResource = null;
        _workers[index].GetComponent<Worker>().IsActive = false;
    }
}
