using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;


public class ShopItemCountToSell : MonoBehaviour
{
    [SerializeField] private Text _countItemText;
    [SerializeField] private Text _countOfSaleText;
    [SerializeField] private Text _goldText;
    [SerializeField] private Inventory _inventory;
    private int _itemPrice;
    private int _currenItemPrice;
    private int _maxCount;
    private IItem _itemForShop;
    private int _index;
    public int CountOfSale;
    public int ItemCountSale;
    public static event Action OnChangeSlot;
    public int CurrenItemPrice => _currenItemPrice;

    public int ItemPrice => _itemPrice;

    private void Awake()
    {

        Slot.OnSlotCelected += CountItemUpdate;
        CountOfSale = 0;
        _maxCount = 0;
        _itemPrice = 0;
        _goldText.text = _itemPrice.ToString();
    }

    public void Up1()
    {
        if (CountOfSale + 1 > _maxCount)
        {
            return;
        }
        CountOfSale += 1;
        CountOfSaleUpdate();
    }
    public void Up10()
    {
        if (CountOfSale + 10 > _maxCount)
        {
            return;
        }
        CountOfSale += 10;
        CountOfSaleUpdate();
    }
    public void Down1()
    {
        if (CountOfSale <= 0)
        {
            return;
        }
        CountOfSale -= 1;
        CountOfSaleUpdate();
    }
    public void Down10()
    {
        if (CountOfSale <= 10)
        {
            CountOfSale = 0;
            CountOfSaleUpdate();
            return;
        }
        CountOfSale -= 10;
        CountOfSaleUpdate();
    }

    public void CountItemUpdate(Slot slot)
    {
        if (_inventory.GetItem(slot.Index) != null)
        {
            OnChangeSlot?.Invoke();
            slot.ShowSelectPanel();
            _index = slot.Index;
            CountOfSale = 0;
            CountOfSaleUpdate();             
            _itemForShop = _inventory.GetItem(slot.Index);
            _countItemText.text = $"{_itemForShop.Count}";
            _maxCount = _itemForShop.Count;
            _itemPrice = _itemForShop.Price;
            
        }
        else
        {
            CountOfSale = 0;
            CountOfSaleUpdate();
            return;
        }
    }

    public void CountOfSaleUpdate()
    {
        _currenItemPrice = 0;
        _countOfSaleText.text = CountOfSale.ToString();
        _currenItemPrice = _itemPrice * CountOfSale;
        _goldText.text = _currenItemPrice.ToString(); 
    }

    public void CountItemUpdate()
    {
        CountOfSale = 0;
        ItemCountSale = _itemForShop.Count;
        _maxCount = _itemForShop.Count;
        _countItemText.text = ItemCountSale.ToString();
        _countOfSaleText.text = CountOfSale.ToString();
        if (_inventory.GetItem(_index) != null)
        {
            _itemForShop = _inventory.GetItem(_index);
        }
    }
   
    public void ToSale(out Sprite sprite, out string name)
    {
        if (_itemForShop != null)
        {
            _inventory.RemoveItemCount(_itemForShop, CountOfSale);
            sprite = _itemForShop.Img;
            name = _itemForShop.Name;            
        }
        else
        {
            sprite = null;
            name = null;            
        }
    }

    public void NameUpdate(out Sprite sprite, out string name)
    {
        sprite = _itemForShop.Img;
        name = _itemForShop.Name;
    }
}
