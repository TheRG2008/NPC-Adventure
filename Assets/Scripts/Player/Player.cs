using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _level = 4;
    private int _gold = 1000;
    private float _currentExp = 100;
    private float _targetExp;
    private int _currentReputation = 0;
    private int _maxReputation = 1000;
    private int[] _expForNextLevel;
    private int _maxWorkerCount;
    public event Action OnMainStatsChanged;
    private int _maxResourceForCollect;
    private int _currentCollectedResourse;
    private IItem _item;
    private Inventory _inventory;

    public int Level 
    { 
        get => _level;
        set 
        {
            _level = value;
            OnMainStatsChanged?.Invoke();
        } 
    }
    public int Gold 
    { 
        get => _gold;
        set
        {
            _gold = value;
            OnMainStatsChanged?.Invoke();
        }
    }
    public float CurrentExp 
    { 
        get => _currentExp;
        set
        {
            _currentExp = value;
            if (_currentExp >= TargetExp)
            {
                _currentExp = 0;
                LevelChange();
            }
            OnMainStatsChanged?.Invoke();
        }
    }
    public int CurrentReputation 
    { 
        get => _currentReputation;
        set
        {
            _currentReputation = value;
            if (_currentReputation >= MaxReputation)
            {
                _currentReputation = MaxReputation;
            }
            OnMainStatsChanged?.Invoke();
        } 
    }
    public float TargetExp 
    { 
        get => _targetExp;
        set 
        {
            _targetExp = value;
            OnMainStatsChanged?.Invoke();
        } 
    }
    public int MaxReputation  => _maxReputation;
    public int MaxWorkerCount 
    { 
        get => _maxWorkerCount; 
        set => _maxWorkerCount = value; 
    }
    public int CurrenCollectedResourse 
    { 
        get => _currentCollectedResourse; 
        set => _currentCollectedResourse = value; 
    }

    private void Start()
    {
        
        _inventory = FindObjectOfType<Inventory>();
        _maxResourceForCollect = 10;
        _currentCollectedResourse = 0;
        _maxWorkerCount = 2;
        _expForNextLevel = new int[] { 200, 400, 600, 800, 1000, 1200 }; 
        TargetExp = _expForNextLevel[0];
        
    }
    public void LevelChange()
    {
        TargetExp = _expForNextLevel[_level];
        _level++;
    }
    public int CollectResource(int countResource, IItem item)
    {
        if (_item == null)
        {
            _currentCollectedResourse += countResource;
            _item = item;               
                
            if (_currentCollectedResourse > _maxResourceForCollect)
            {
                int count = countResource - (_currentCollectedResourse - _maxResourceForCollect);
                _currentCollectedResourse = _maxResourceForCollect;
                
                _inventory.AddItem(_item, count);
                return count;
            }
            
            _inventory.AddItem(_item, countResource);
            return countResource;
            
        }
        else if (_item.TypeResorce == item.TypeResorce)
        {
            if (_currentCollectedResourse < _maxResourceForCollect)
            {
                _currentCollectedResourse += countResource;
                if (_currentCollectedResourse > _maxResourceForCollect)
                {
                    int count = countResource - (_currentCollectedResourse - _maxResourceForCollect);
                    _currentCollectedResourse = _maxResourceForCollect;                    
                    _inventory.AddItem(_item, count);
                    return count;
                }
            }
            
        }
       
        return 0;
    }
}
