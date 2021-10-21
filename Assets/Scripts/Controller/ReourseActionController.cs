using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReourseActionController : MonoBehaviour
{
    [SerializeField] private RayCastController _rayCast;
    [SerializeField] private Player _player;
    [SerializeField] private Inventory _inventory;
    public PlayerMove PlayerMove; 
    public void CollectResourse()
    {

    }

    public void AddWorkerForResourse()
    {

    }

    public void DoNothing()
    {
        PlayerMove.StartMove();
    }

    

}
