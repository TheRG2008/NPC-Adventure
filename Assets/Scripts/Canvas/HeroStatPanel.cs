using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroStatPanel : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Image _img;
    [SerializeField] private Text _level;
    [SerializeField] private Text _damage;
    [SerializeField] private Text _defence;
    [SerializeField] private Text _hp;
    [SerializeField] private Text _sp;

    [SerializeField] private Text _addDamage;
    [SerializeField] private Text _addDefence;
    [SerializeField] private Text _addHP;
    [SerializeField] private Text _addSP;

    [SerializeField] private Text _gold;
    [SerializeField] private Image[] _equipImg;
    private HeroList _heroList;
    private Hero _hero;
    private GameObject _heroGameObject;
    private int _currentDefence;
    private float _currentHP;
    private float _curentSP;
    private int _currentDamage;

    private void Start()
    {
        _heroList = FindObjectOfType<HeroList>();
        HeroSlot.OnHeroStatsUpdate += StatsUpdate;
        CleanEquipSlots();
        gameObject.SetActive(false);
    }
   
    public void StatsUpdate(HeroSlot heroSlot)
    {
        CleanEquipSlots();
        _currentDefence = 0;
        _currentHP = 0;
        _currentDamage = 0;
        _curentSP = 0;
        _addDefence.text = _currentDefence.ToString();
        _addHP.text = _currentHP.ToString();
        _addDamage.text = _currentDamage.ToString();
        _addSP.text = _curentSP.ToString();
        _heroGameObject = heroSlot.HeroGameObject;
        _hero = heroSlot.HeroGameObject.GetComponent<Hero>();
        _name.text = _hero.Name;
        _img.sprite = _hero.ImgHero;
        _level.text = _hero.Level.ToString();
        _damage.text = _hero.Damage.ToString();
        _defence.text = _hero.Defence.ToString();
        _hp.text = _hero.MaxHP.ToString();
        _sp.text = _hero.MaxSP.ToString();
        _gold.text = _hero.GoldForRent.ToString();

        if (_hero.StartEqipment.Count == 0)
        {
            return;
        }
        for (int i = 0; i < _equipImg.Length; i++)
        {
            for (int j = 0; j < _hero.StartEqipment.Count; j++)
            {
                if(_equipImg[i].gameObject.GetComponent<HeroInventorySlot>().TypeResorce == _hero.StartEqipment[j].TypeResorce)
                {
                    _equipImg[i].gameObject.SetActive(true);
                    _equipImg[i].sprite = _hero.StartEqipment[j].Img;
                    ShowAddStats(_hero.StartEqipment[j].TypeResorce, j);
                }
            }
        }
    }

    public void CleanEquipSlots()
    {
        for (int i = 0; i < _equipImg.Length; i++)
        {
            _equipImg[i].gameObject.SetActive(false);
        }
    }

    private void ShowAddStats(TypeResorce typeResorce, int index)
    {
        if(typeResorce == TypeResorce.Armor)
        {
            _currentDefence += _hero.StartEqipment[index].Defence;
            _currentHP += _hero.StartEqipment[index].Hp;
            _curentSP += _hero.StartEqipment[index].Sp;
            _addDefence.text = _currentDefence.ToString();
            _addHP.text = _currentHP.ToString();
            _addSP.text = _curentSP.ToString();

        }
        if (typeResorce == TypeResorce.Head)
        {
            _currentDefence += _hero.StartEqipment[index].Defence;
            _currentHP += _hero.StartEqipment[index].Hp;
            _curentSP += _hero.StartEqipment[index].Sp;
            _addDefence.text = _currentDefence.ToString();
            _addHP.text = _currentHP.ToString();
            _addSP.text = _curentSP.ToString();
        }
        if (typeResorce == TypeResorce.Weapon)
        {
            _currentDamage += _hero.StartEqipment[index].Damage;
            _addDamage.text = _currentDamage.ToString();
        }
    }

    public void BuyHero()
    {
        _heroList.AddHero(_heroGameObject);
    }
}
