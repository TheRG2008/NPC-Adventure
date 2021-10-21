using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    [SerializeField] private GroundCell[] _groundCells;
    [SerializeField] private GameObject[] _enemyes;
    [SerializeField] private Player _player;
    private int _maxCellWithEnemy;

    private void Start()
    {
        ShowResourse();
    }

    public void UpdateCell()
    {
        GetCellWithEnemy();
        AddActiveEnemy();
        ShowEnemyes();
    }

    private void ShowEnemyes()
    {
        for (int i = 0; i < _groundCells.Length; i++)
        {
            if (_groundCells[i].ActiveEnemy != null)
            {
                _groundCells[i].ShowEnemy();
            }
        }
    }

    private void ShowResourse()
    {
        for (int i = 0; i < _groundCells.Length; i++)
        {
            if (_groundCells[i].ActiveResource != null)
            {
                _groundCells[i].ShowResource();
            }
        }

    }

    private void AddActiveEnemy()
    {
      
        for (int i = 0; i < _groundCells.Length; i++)
        {
            int randomCell = Random.Range(0, _groundCells.Length);
            GroundCell groundCell = _groundCells[randomCell];
            if (groundCell.ActiveEnemy == null)
            {
                if (groundCell.IsOpen == true)
                {
                    _groundCells[randomCell].AddEnemy(_enemyes[0]);
                    //_groundCells[randomCell].ActiveEnemy = _enemyes[0];
                    _maxCellWithEnemy--;
                    if (_maxCellWithEnemy <= 0)
                    {
                        return;
                    }
                }
            }
        }
        
    }

    private void GetCellWithEnemy()
    {
        int openCell = 0;
        for (int i = 0; i < _groundCells.Length; i++)
        {
            if(_groundCells[i].IsOpen == true)
            {
                openCell++;
            }            
        }
        if (openCell == 0)
        {
            _maxCellWithEnemy = 0;
        }
        else if (openCell > 0 && openCell <= 10)
        {
            _maxCellWithEnemy = 1;
        }
        else if (openCell > 10 && openCell <= 20)
        {
            _maxCellWithEnemy = 2;
        }
        else if (openCell > 20 && openCell <= 30)
        {
            _maxCellWithEnemy = 3;
        }
        else if (openCell > 30)
        {
            _maxCellWithEnemy = 4;
        }
    }
}
