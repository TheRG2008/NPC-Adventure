using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class HelperCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _worker;
    
    //public static event Action<HelperCanvas> OnHeroStatsUpdate;
    public static event Action<HelperCanvas> OnWorkerStatsUpdate;

    public GameObject Worker => _worker;


    //public void CelectHero()
    //{
    //    OnHeroStatsUpdate?.Invoke(this);        
    //}
    public void CelectWorker()
    {
        OnWorkerStatsUpdate?.Invoke(this);
    }
}
