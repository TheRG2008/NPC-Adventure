using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    [SerializeField] private Text _count;
    [SerializeField] private Image _img;
    private IItem _curentItem;
    private int _itemCount;
    private string _name;
    public bool IsBusy;
    

    public IItem CurentItem => _curentItem;

    public int ItemCount 
    { 
        get => _itemCount; 
        set => _itemCount = value;
    }
    public string Name => _name;

    private void Awake()
    {
        IsBusy = false;
    }
    public void SlotUpdate(int countText, Sprite img, string name)
    {
        _count.text = countText.ToString();
        _itemCount = countText;
        _img.sprite = img;
        _name = name;        
    }

    public void SlotUpdate(int countText)
    {
        _itemCount += countText;
        _count.text = _itemCount.ToString();
        
    }

    public void ItemUpdate(IItem item, int count)
    {
        _curentItem = item;
        _itemCount = count;
    }
}
