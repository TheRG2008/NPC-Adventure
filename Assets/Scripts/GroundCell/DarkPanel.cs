using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DarkPanel : MonoBehaviour
{
    [SerializeField] private GameObject _selectPanel;
    private bool _isTriger = false;
    public bool IsTriger 
    { 
        get => _isTriger; 
        set => _isTriger = value; 
    }

    public void ShowCelectPanel()
    {
        _selectPanel.SetActive(true);
    }
    public void HideCelectPanel()
    {
        _selectPanel.SetActive(false);
    }

}
