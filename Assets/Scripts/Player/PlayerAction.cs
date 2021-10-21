using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private GameObject _buttonOpenPanel;
    private GameObject _darkPanels;
    private int _maxPanelOpenInCurrentDay;
    [SerializeField] private PanelsManager _panelsManager;

    private void Start()
    {
        ChangeMaxOpenPanel();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DarkPanel>())
        {
            other.gameObject.GetComponent<DarkPanel>().IsTriger = true;
            _darkPanels = other.gameObject;
            _buttonOpenPanel.SetActive(true);
            other.gameObject.GetComponent<DarkPanel>().ShowCelectPanel();
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<DarkPanel>())
        {
            other.gameObject.GetComponent<DarkPanel>().IsTriger = false;
            _buttonOpenPanel.SetActive(false);
            _darkPanels = null;
            other.gameObject.GetComponent<DarkPanel>().HideCelectPanel();
        }
    }
    public void ResearchCell()
    {
        if (_darkPanels != null)
        {
            if(_maxPanelOpenInCurrentDay <= 0)
            {
                _panelsManager.ShowMaxDarkPanelAlert();
                return;
            }
            GroundCell groundCell = _darkPanels.GetComponentInParent<GroundCell>();
            groundCell.OpenGroundCell();
            _darkPanels.SetActive(false);
            _darkPanels = null;
            _buttonOpenPanel.SetActive(false);
            _maxPanelOpenInCurrentDay--;
        }
        
    }

   private void ChangeMaxOpenPanel()
    {
        _maxPanelOpenInCurrentDay = 3;
    }
}
