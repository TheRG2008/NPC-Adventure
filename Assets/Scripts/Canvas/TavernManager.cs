using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _heroesLevel1;
    [SerializeField] private GameObject[] _heroesLevel2;
    [SerializeField] private GameObject[] _heroesLevel3;    
    [SerializeField] private GameObject[] _heroSlot;
    [SerializeField] private GameObject[] _workerSlot;
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }
    public GameObject GetHero()
    {
        if(_player.Level > 3)
        {
            int rand = Random.Range(0, _heroesLevel1.Length);
            return _heroesLevel1[rand];
        }
        if (_player.Level > 10)
        {
            int rand = Random.Range(0, _heroesLevel2.Length);
            return _heroesLevel2[rand];
        }
        if (_player.Level > 20)
        {
            int rand = Random.Range(0, _heroesLevel3.Length);
            return _heroesLevel3[rand];
        }
        return null;
    }

    public void ChangeHeroSlotCount()
    {
        if(_player.Level > 3)
        {
            _heroSlot[0].SetActive(true);
        }
        if(_player.Level > 10)
        {
            _heroSlot[1].SetActive(true);
        }
        if (_player.Level > 30)
        {
            _heroSlot[2].SetActive(true);
        }

    }
    public void ChangeWorkerSlotCount()
    {
        if (_player.Level > 2)
        {
            _workerSlot[0].SetActive(true);
        }
        if (_player.Level > 5)
        {
            _workerSlot[1].SetActive(true);
        }
        if (_player.Level > 10)
        {
            _workerSlot[2].SetActive(true);
        }
    }

    public void ChangeHero()
    {
        for (int i = 0; i < _heroSlot.Length; i++)
        {
            _heroSlot[i].GetComponent<HeroSlot>().ChangeHeroInTavern();
        }
    }
}
