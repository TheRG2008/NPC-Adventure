using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<GameObject> _shopSlots;    
    [SerializeField] private ShopItemCountToSell _shopItem;
    [SerializeField] private GameObject _enoughSpacePanel;
    [SerializeField] private GameObject _enoughMoneyPanel;
    [SerializeField] private Text _slotPriceText;
    [SerializeField] private Player _player;
    private int _pricePerSlot;

    private void Start()
    {
        _pricePerSlot = 100;
        _slotPriceText.text = _pricePerSlot.ToString();
    }

    private string _name;
    private Sprite _img;
    
    public void ShopSlotsUpdate()
    {
        _shopItem.NameUpdate(out _img, out _name);
        int itemCount = _shopItem.CountOfSale;        
        if (itemCount == 0)
        {
            return;
        }

        for (int i = 0; i < _shopSlots.Count; i++)
        {
            ShopSlot shopSlots = _shopSlots[i].GetComponent<ShopSlot>();
            if (!_shopSlots[i].GetComponent<ShopSlot>().IsBusy && _shopSlots[i].activeInHierarchy)
            {
                _shopItem.ToSale(out _img, out _name);
                shopSlots.SlotUpdate(itemCount, _img, _name);                
                shopSlots.IsBusy = true;
                _shopItem.CountItemUpdate();
                
                return;               
            }
            else if (_name == shopSlots.Name)
            {
                _shopItem.ToSale(out _img, out _name);
                shopSlots.SlotUpdate(itemCount);
                _shopItem.CountItemUpdate();
                return;
            }   
        }
        int activeCount = 0;
        int openSlotCount = 0;
        for (int i = 0; i < _shopSlots.Count; i++)
        {
            ShopSlot shopSlots = _shopSlots[i].GetComponent<ShopSlot>();
            if (shopSlots.IsBusy == true)
            {
                openSlotCount++;
            }
            if (_shopSlots[i].activeInHierarchy)
            {
                activeCount++;
            }
        }
        if (openSlotCount == activeCount)
        {
            StartCoroutine(ShowPanel(_enoughSpacePanel));
            return;
        }
    }
    
    private IEnumerator ShowPanel (GameObject panel)
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(1f);
        Debug.Log("Прошло пол секунды");
        panel.SetActive(false);
    }

    public void BuySlot()
    {
        if (_player.Gold < _pricePerSlot)
        {
            StartCoroutine(ShowPanel(_enoughMoneyPanel));
            return;
        }
        _player.Gold -= _pricePerSlot;
        for (int i = 0; i < _shopSlots.Count; i++)
        {
            if(!_shopSlots[i].activeInHierarchy)
            {
                _shopSlots[i].SetActive(true);
                ChangeSlotPrice();
                return;
            }
        }
    }

    private void ChangeSlotPrice()
    {
        _pricePerSlot = _pricePerSlot * 3;
        _slotPriceText.text = _pricePerSlot.ToString();
    }

   



}
