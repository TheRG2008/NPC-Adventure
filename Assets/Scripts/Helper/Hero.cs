using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private int _damage;
    [SerializeField] private int _defence;
    [SerializeField] private int _goldForRent;
    [SerializeField] private List<Equipment> _startEqipment;
    [SerializeField] private ResourceForTest[] _resourseForRent;
    [SerializeField] private TypeHero _typeHero;
    [SerializeField] private float _maxHP;
    [SerializeField] private float _maxSP;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _imgHero;
    private int _goldFromEnemy;
    private float _expFromEnemy;
    private float _currentHP;
    private float _currentSP;
    private List<ResourceForTest> _resourcesFromEnemy;
    private Enemy _enemy;

    public float CurrentHP 
    { 
        get => _currentHP; 
        set
        {
            _currentHP = value;
            if (_currentHP <= 0)
            {
                Die();
            }
        }
    }
    public int GoldFromEnemy 
    { 
        get => _goldFromEnemy; 
        set => _goldFromEnemy = value; 
    }
    public float ExpFromEnemy 
    { 
        get => _expFromEnemy; 
        set => _expFromEnemy = value; 
    }
    public float CurrentSP 
    { 
        get => _currentSP; 
        set => _currentSP = value; 
    }
    public Sprite ImgHero => _imgHero;
    public string Name => _name;
    public int Level => _level;
    public int Damage 
    { 
        get => _damage; 
        set => _damage = value; 
    }
    public int Defence 
    { 
        get => _defence; 
        set => _defence = value; 
    }
    public int GoldForRent => _goldForRent;
    public float MaxHP 
    { 
        get => _maxHP; 
        set => _maxHP = value; 
    }
    public float MaxSP 
    { 
        get => _maxSP; 
        set => _maxSP = value; 
    }
    public List<Equipment> StartEqipment  => _startEqipment;

    private void Start()
    {
        CurrentHP = MaxHP;
        CurrentSP = MaxSP;
    }
    private void Atack()
    {
        _enemy.GetDamage(Damage);
    }

    public void GetDamage(int damage)
    {
        damage -= Defence;
        if (damage < 0)
        {
            damage = 0;
        }
        CurrentHP -= damage;
    }

    private void Die()
    {
        
    }

    public void GetResourceFromEnemy()
    {
        for (int i = 0; i < _enemy.EnemyResources.Count; i++)
        {
            _resourcesFromEnemy.Add(_enemy.EnemyResources[i]);
        }
        GoldFromEnemy = _enemy.Gold;
        ExpFromEnemy = _enemy.Exp;
    }

    public void ClearHeroLoot()
    {
        GoldFromEnemy = 0;
        ExpFromEnemy = 0;
        _resourcesFromEnemy.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            _enemy = other.gameObject.GetComponent<Enemy>();
            gameObject.GetComponent<HelperMove>().StopMove();
            _enemy.Hero = this;
            _enemy.Atack();

        }
    }

}
