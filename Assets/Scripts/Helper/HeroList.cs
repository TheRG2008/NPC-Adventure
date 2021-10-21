using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroList : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] PanelsManager _panelsManager;
    private List<GameObject> _heroes;

    private void Start()
    {
        _heroes = new List<GameObject>();
    }

    public GameObject GetHero(int index)
    {
        return _heroes[index];
    }

    public void AddHero(GameObject hero)
    {
        if (_player.Gold < hero.GetComponent<Hero>().GoldForRent)
        {
            _panelsManager.ShowNotEnoughGoldPanel();
            return;
        }
        _player.Gold -= hero.GetComponent<Hero>().GoldForRent;
        _heroes.Add(hero);
        Debug.Log("Герой нанят");
    }
}
