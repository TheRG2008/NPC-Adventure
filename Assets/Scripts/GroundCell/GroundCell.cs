using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCell : MonoBehaviour
{
    [SerializeField] private TypeGround _typeGround = TypeGround.Passable;
    [SerializeField] private Transform _pointForObject;
    [SerializeField] private int _levelCell;
    [SerializeField] private GameObject _activeEnemy;    
    [SerializeField] private ResourceForTest _activeResource;
    [SerializeField] private int _countResource;

    private bool _isHaveEnemy;
    private bool _isOpen = false;
    private int _index;

    public bool IsHaveEnemy 
    { 
        get => _isHaveEnemy;
        set => _isHaveEnemy = value; 
    }    
    public ResourceForTest ActiveResource 
    { 
        get => _activeResource; 
        set => _activeResource = value;
    }
    public GameObject ActiveEnemy 
    { 
        get => _activeEnemy; 
        set => _activeEnemy = value; 
    }
    public int Index 
    { 
        get => _index; 
        set => _index = value; 
    }
    public int LevelCell => _levelCell;
    public TypeGround TypeGround => _typeGround;
    public Transform PointForObject => _pointForObject;
    public bool IsOpen => _isOpen;
   

    public void AddEnemy (GameObject enemy)
    {
        if (_activeEnemy == null)
        {
            _activeEnemy = enemy;
        }
    }

    public void ShowEnemy()
    {
        Instantiate(_activeEnemy, _pointForObject);
    }
    public void ShowResource()
    {
        Instantiate(_activeResource, _pointForObject);
    }
    
    public ResourceForTest GiveResource (int workerResourceCount, out int resourseCount)
    {
        resourseCount = workerResourceCount;
        
        if(workerResourceCount > _countResource)
        {
            resourseCount = workerResourceCount - _countResource;
            _countResource = 0;
        }
        _countResource -= workerResourceCount;
        return _activeResource;
    }

    public void OpenGroundCell ()
    {
        _isOpen = true;
    }
}
