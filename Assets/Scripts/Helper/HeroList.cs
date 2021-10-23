using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroList : MonoBehaviour
{
    private Player _player;
    private PanelsManager _panelsManager;
    private List<GameObject> _heroes;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _panelsManager = FindObjectOfType<PanelsManager>();
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
            _panelsManager.Show(Panels.NotEnoughGold);
            return;
        }
        _player.Gold -= hero.GetComponent<Hero>().GoldForRent;
        _heroes.Add(hero);
        Debug.Log("Герой нанят");
    }
}
