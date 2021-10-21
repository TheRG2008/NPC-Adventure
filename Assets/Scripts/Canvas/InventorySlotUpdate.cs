using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUpdate : MonoBehaviour
{       
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Slot[] _slot;

    private void Start()
    {
        AddSlotID();
        //UpdateSlots();
        _inventory.OnStateChanged += UpdateSlots;
    }

    public void UpdateSlots()
    {
        for (int i = 0; i < _slot.Length; i++)
        {
            _slot[i].CleanSlot();
        }
        for (int i = 0; i < _inventory.Items.Count; i++)
        {
            if (_inventory.GetItem(i) != null)
            {
                IItem item = _inventory.GetItem(i);
                _slot[i].SlotUpdate(item.Count, item.Img);
            }

        }
    }

    private void AddSlotID()
    {
        int counter = 0;
        for (int i = 0; i < _slot.Length; i++)
        {
            _slot[i].ID = counter;
            counter++;
        }
    }
}
