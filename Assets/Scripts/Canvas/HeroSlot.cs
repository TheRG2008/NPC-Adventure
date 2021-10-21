using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HeroSlot : MonoBehaviour
{
    [SerializeField] private TavernManager _tavernManager;   
    [SerializeField] private Text _nameHero;
    private GameObject _heroGameObject;
    private Hero _hero;
    public static event Action<HeroSlot> OnHeroStatsUpdate;

    public GameObject HeroGameObject => _heroGameObject;
    public Hero Hero => _hero;

    private void Start()
    {
        ChangeHeroInTavern();
    }

    private void HeroSlotUpdate()
    {
        gameObject.GetComponent<Image>().sprite = _hero.ImgHero;
        _nameHero.text = _hero.Name;
    }

    public void ChoiseHero()
    {
        OnHeroStatsUpdate?.Invoke(this);
    }

    public void ChangeHeroInTavern()
    {
        _heroGameObject = _tavernManager.GetHero();
        _hero = _heroGameObject.GetComponent<Hero>();
        HeroSlotUpdate();
    }
}
