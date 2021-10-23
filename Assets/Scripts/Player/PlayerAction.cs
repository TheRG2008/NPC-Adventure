using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{   
    private GameObject _darkPanels;
    private int _maxPanelOpenInCurrentDay;
    private PanelsManager _panelsManager;

    private void Start()
    {
        _panelsManager = FindObjectOfType<PanelsManager>();
        ChangeMaxOpenPanel();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DarkPanel>())
        {
            other.gameObject.GetComponent<DarkPanel>().IsTriger = true;
            _darkPanels = other.gameObject;
            _panelsManager.Show(Panels.OpenDarkPanelShow);            
            other.gameObject.GetComponent<DarkPanel>().ShowCelectPanel();
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<DarkPanel>())
        {
            other.gameObject.GetComponent<DarkPanel>().IsTriger = false;
            _panelsManager.Show(Panels.OpenDarkPanelHide);
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
                _panelsManager.Show(Panels.MaxDarkPanel);
                _panelsManager.Show(Panels.OpenDarkPanelHide);
                return;
            }
            GroundCell groundCell = _darkPanels.GetComponentInParent<GroundCell>();
            groundCell.OpenGroundCell();
            _darkPanels.SetActive(false);
            _darkPanels = null;
            _panelsManager.Show(Panels.OpenDarkPanelHide);
            _maxPanelOpenInCurrentDay--;
        }
        
    }

   private void ChangeMaxOpenPanel()
    {
        _maxPanelOpenInCurrentDay = 3;
    }
}
