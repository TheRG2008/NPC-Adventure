using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private GameObject _townPanel;
    [SerializeField] private GameObject _enterTownCheck;
    private PlayerMove _playerMove;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMove>())
        {
            _playerMove = other.gameObject.GetComponent<PlayerMove>();
            _enterTownCheck.SetActive(true);
            
        }
    }

    public void EnterTown()
    {
        _enterTownCheck.SetActive(false);
        _townPanel.SetActive(true);
    }

    public void NotEnterTown()
    {
        _enterTownCheck.SetActive(false);
        
    }
}
