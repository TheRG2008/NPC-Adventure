using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerStatPanel : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Image _img;
    [SerializeField] private Text _level;
    [SerializeField] private Text _gold;
    [SerializeField] private Text _discription;
    [SerializeField] private Text _maxResourseCount;
    [SerializeField] private Text _addResourse;
    [SerializeField] private Image _equipImg;
    [SerializeField] private WorkerList _workerList;
    private Worker _worker;
    private GameObject _workerGameObject;
    private int _currentAddResourse;

    private void Start()
    {
        HelperCanvas.OnWorkerStatsUpdate += StatsUpdate;
        gameObject.SetActive(false);
    }

    public void StatsUpdate(HelperCanvas workerStats)
    {
        _equipImg.gameObject.SetActive(false);
        _currentAddResourse = 0;
        _addResourse.text = _currentAddResourse.ToString();
        _worker = workerStats.Worker.GetComponent<Worker>();
        _workerGameObject = workerStats.Worker;
        _worker.ChangeMaxCountResorceCollect();
        _name.text = _worker.Name;
        _img.sprite = _worker.Img;
        _level.text = _worker.Level.ToString();
        _gold.text = _worker.GoldForRent.ToString();
        _discription.text = _worker.Discription;
        _maxResourseCount.text = _worker.MaxCountResorceCollect.ToString();
        if (_worker.StartEquipment != null)
        {
            _equipImg.gameObject.SetActive(true);
            _addResourse.text = _worker.StartEquipment.Weight.ToString();
            _equipImg.sprite = _worker.StartEquipment.Img;
        }
    }

    public void BuyWorker()
    {
        _workerList.AddWorker(_workerGameObject);
    }
}
