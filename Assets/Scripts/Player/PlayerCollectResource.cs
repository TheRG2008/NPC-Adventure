using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectResource : MonoBehaviour
{
    private RayCastController _rayCast;
    private PanelsManager _panelsManager;
    private Player _player;
    private Inventory _inventory;
    private IItem _item;
    private int _currentCollectedResourse;
    private int _maxResourceForCollect;

    private void Start()
    {
        _maxResourceForCollect = 10;
        _inventory = FindObjectOfType<Inventory>();
        _rayCast = FindObjectOfType<RayCastController>();
        _panelsManager = FindObjectOfType<PanelsManager>();
        _player = FindObjectOfType<Player>();
    }
    public void CollectResource()
    {
        int count = CollectResource(_maxResourceForCollect, _rayCast.Resource);
        if (count > 0)
        {
            _panelsManager.Show(Panels.CollectResource);
            return;
        }
        _panelsManager.Show(Panels.Impossible);
    }

    public int CollectResource(int countResource, IItem item)
    {
        if (_item == null)
        {
            int removeCount = item.RemoveItem(countResource);
            _currentCollectedResourse += removeCount;
            _item = _rayCast.Resource.Copy();
            _item.Count = _currentCollectedResourse;
            _inventory.AddItem(_item);
            return _currentCollectedResourse;
        }
       
        return 0;
    }
}
