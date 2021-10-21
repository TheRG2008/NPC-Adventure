using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class InventoryTest : MonoBehaviour, IInventory
{
    //[SerializeField] private int _size;
    private List<IItem> _items;
    //private IItem[] _items;
    public int Size { get; }
    public event Action OnStateChanged;


    private void Start()
    {
        _items = new List<IItem>();
    }

    //public Inventory(int size)
    //{
    //    Size = size;
    //    _items = new IItem[size];

    //}

    public bool CheckItem(IItem item)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i] == item)
                return true;
        }
        return false;

    }
    private bool _AddItem(IItem item)
    {

        _items.Add(item);
        OnStateChanged?.Invoke();
        Debug.Log($"{item.Name} new Item add inventory with count {item.Count}");
        return true;
        //for (int i = 0; i < _items.Count; i++)
        //{
        //    if (_items[i] == null)
        //    {
        //        _items[i] = item;
        //        OnStateChanged?.Invoke();
        //        return true;
        //    }
        //}
        //return false;
    }

    public bool AddItem(IItem item)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i] != null && _items[i].Name == item.Name)
            {
                _items[i].Count += item.MinCount;
                Debug.Log($"{_items[i].Name} change count + {item.Count}");
                if (_items[i].Count > item.MaxCount)
                {
                    _items[i].Count = item.MaxCount;
                }
                OnStateChanged?.Invoke();
                return true;
            }
        }
        return _AddItem(item);
    }
    public bool RemoveItem(IItem item)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i] == item)
            {
                _items[i].Count -= item.Count;
                if (_items[i].Count <= 0)
                {
                    _items[i].Count = 0;
                }
                OnStateChanged?.Invoke();
                return true;
            }
        }
        return false;
    }

    public bool RemoveItemCount(IItem item, int count)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i] == item)
            {
                _items[i].Count -= count;
                if (_items[i].Count <= 0)
                {

                    _items[i].Count = 0;
                }
                OnStateChanged?.Invoke();
                return true;
            }
        }
        return false;

    }

    public IItem GetItem(int index)
    {
        return _items[index];
    }

    public T GetItem<T>(int index) where T : IItem
    {
        return (T)_items[index];
    }
}

