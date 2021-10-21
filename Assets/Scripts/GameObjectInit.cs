using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectInit : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;
    [SerializeField] private Transform _transform;
    private PanelsManager _panelsManager;
    private PlayerMove _playerMove;
    private void Awake()
    {
        //GameObject instance = Instantiate(Resources.Load("PlayerInventory", typeof(GameObject))) as GameObject;
        //Instantiate(_inventory, _transform);
        //_panelsManager = new PanelsManager();
        //_playerMove = new PlayerMove();
    }
}
