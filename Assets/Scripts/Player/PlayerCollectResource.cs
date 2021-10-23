using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectResource : MonoBehaviour
{
    private RayCastController _rayCast;
    private PanelsManager _panelsManager;
    private Player _player;

    private void Start()
    {
        _rayCast = FindObjectOfType<RayCastController>();
        _panelsManager = FindObjectOfType<PanelsManager>();
        _player = FindObjectOfType<Player>();
    }
    public void CollectResource()
    {
        
        if (_rayCast.Resource.Count > 0)
        {
            int deleteResourceCount = _player.CollectResource(_rayCast.Resource.Count, _rayCast.Resource);
            if (deleteResourceCount > 0)
            {
                _rayCast.Resource.RemoveItem(deleteResourceCount);
                _panelsManager.Show(Panels.CollectResource);
                return;
            }
            
        }

        _panelsManager.Show(Panels.Impossible);
    }
}
