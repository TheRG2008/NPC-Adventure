using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Text _count;
    [SerializeField] private Image _img;
    [SerializeField] private Button _selectButton;
    [SerializeField] private GameObject _selectPanel;
    private int _id;
    public int Index;    
    public static event Action<Slot> OnSlotCelected;

    private void Start()
    {
        ShopItemCountToSell.OnChangeSlot += HideSelectPanel;
    }
    public int ID 
    { 
        set => _id = value; 
    }

    public void SlotUpdate(int countText, Sprite img)
    {
        _count.text = countText.ToString();
        _img.sprite = img;
    }

    public void CleanSlot()
    {
        _count.text = null;
        _img.sprite = null;
    }

    private int SelectSlot()
    {
        if (_selectButton.gameObject.GetComponent<Slot>()._img != null)
        {
            _selectButton.Select();
            Debug.Log(_id);
            return _id;

        }
        else
            Debug.Log("SelectButton was null");
        return 0;

    }
    public void GetIndexID()
    {
        Index = SelectSlot();
        OnSlotCelected?.Invoke(this);
    }

    public void ShowSelectPanel()
    {
        _selectPanel.SetActive(true);
    }

    public void HideSelectPanel()
    {
        _selectPanel.SetActive(false);
    }
}
