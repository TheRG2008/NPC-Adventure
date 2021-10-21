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
    public event Action OnMainStatsChanged;

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

    private void Start()
    {
        _expForNextLevel = new int[] { 200, 400, 600, 800, 1000, 1200 }; 
        TargetExp = _expForNextLevel[0];
        
    }
    public void LevelChange()
    {
        TargetExp = _expForNextLevel[_level];
        _level++;
    }

}
