using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerList : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] PanelsManager _panelsManager;
    private List<GameObject> _workers;


    private void Start()
    {
        _workers = new List<GameObject>();
    }
    public GameObject GetWorker(int index)
    {
        return _workers[index];
    }

    public void AddWorker(GameObject worker)
    {
        if(_player.Gold < worker.GetComponent<Worker>().GoldForRent)
        {
            _panelsManager.ShowNotEnoughGoldPanel();
            return;
        }
        _player.Gold -= worker.GetComponent<Worker>().GoldForRent;
        _workers.Add(worker);
        Debug.Log("Рабочий нанят");
    }
}
