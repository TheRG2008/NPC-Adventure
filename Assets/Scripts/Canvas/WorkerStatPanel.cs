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
    [SerializeField] private GameObject[] _elementForHide;
    [SerializeField] private GameObject[] _workerControlButtons;
    [SerializeField] private GameObject _choiseButton;
    [SerializeField] private GameObject _removeButton;
    private WorkerList _workerList;
    private WorkersCurrent _workersCurrent;
    private WorkerSlotAdd _workerSlotAdd;
    private Worker _worker;
    private GameObject _workerGameObject;
    private int _currentAddResourse;
    private int _workerIndex;
    private RayCastController _rayCast;
    private PanelsManager _panelsManager;

   

    private void Start()
    {
        _panelsManager = FindObjectOfType<PanelsManager>();
        _rayCast = FindObjectOfType<RayCastController>();
        _workerList = FindObjectOfType<WorkerList>();
        WorkerSlot.OnWorkerStatsUpdate += StatsUpdate;
        WorkerSlot.OnWorkerStatsUpdate += ShowByeWorkerElements;
        WorkerSlot.OnWorkerStatsUpdate += HideWorkerControlButton;
        WorkerSlotAdd.OnWorkerAddStatsUpdate += StatsUpdate;
        WorkerSlotAdd.OnWorkerAddStatsUpdate += HideByeWorkerElements;
        WorkerSlotAdd.OnWorkerAddStatsUpdate += ShowWorkerControlButton;
        WorkerSlotAdd.OnWorkerIndexUpdate += WorkerIndexAndButtonUpdate;
        gameObject.SetActive(false);
    }
    public void StatsUpdate(Worker worker)
    {
        _equipImg.gameObject.SetActive(false);
        _currentAddResourse = 0;
        _addResourse.text = _currentAddResourse.ToString();
        _worker = worker;
        _workerGameObject = worker.gameObject;
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

    private void HideByeWorkerElements(Worker worker)
    {
        for (int i = 0; i < _elementForHide.Length; i++)
        {
            _elementForHide[i].SetActive(false);
        }
    }
    private void ShowByeWorkerElements(Worker worker)
    {
        for (int i = 0; i < _elementForHide.Length; i++)
        {
            _elementForHide[i].SetActive(true);
        }
    }
    private void ShowWorkerControlButton(Worker worker)
    {
        for (int i = 0; i < _workerControlButtons.Length; i++)
        {
            _workerControlButtons[i].SetActive(true);
        }
    }
    private void HideWorkerControlButton(Worker worker)
    {
        for (int i = 0; i < _workerControlButtons.Length; i++)
        {
            _workerControlButtons[i].SetActive(false);
        }
    }
    private void WorkerIndexAndButtonUpdate (WorkerSlotAdd workerSlotAdd)
    {
        _workerSlotAdd = workerSlotAdd;
        _workerIndex = workerSlotAdd.Index;
        if(workerSlotAdd.IsChoise == true)
        {
            _choiseButton.SetActive(false);
            _removeButton.SetActive(true);
        }
        else
        {
            _choiseButton.SetActive(true);
            _removeButton.SetActive(false);
        }
    }

    public void BuyWorker()
    {
        _workerList.AddWorker(_workerGameObject);
    }
    public void DeleteWorker()
    {
        _workersCurrent = FindObjectOfType<WorkersCurrent>();
        _workerSlotAdd.HideCheckMark();        
        RemoveWorker();
        _workerList.RemoveWorker(_workerIndex);        
        _workersCurrent.WorkerSlotUpdate();
        gameObject.SetActive(false);
    }

    public void ChoiseWorker()
    {
        Worker worker = _workerList.GetWorkerScript(_workerIndex);
        if(worker.TypelootResorce == _rayCast.Resource.TypeLoot)
        {
            //_workerList.GetTarget(_rayCast.Transform, _workerIndex);
            _workerList.AddTarget(_rayCast.Transform, _workerIndex);
            _workerSlotAdd.ShowCheckMark();            
            _panelsManager.Show(Panels.WorkerSelected);
            gameObject.SetActive(false);
        }
        else
        {
            _panelsManager.Show(Panels.Impossible);
            gameObject.SetActive(false);
        }

    }

    public void RemoveWorker()
    {
        _workerList.RemoveTarget(_workerIndex);             
        _workerSlotAdd.HideCheckMark();        
    }

  
}
