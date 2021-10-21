using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private int _gold;
    [SerializeField] private float _exp;
    [SerializeField] private int _damage;
    [SerializeField] private int _defence;
    [SerializeField] private float _maxHP;
    [SerializeField] private TypeEnemy _typeEnemy;
    private float _currentHP;
    public Hero Hero;
    public List<ResourceForTest> EnemyResources;

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

    public int Gold => _gold;
    public float Exp => _exp; 

    public void Atack ()
    {
        Hero.GetDamage(_damage);
    }

    public void GetDamage(int damage)
    {
        damage -= _defence;
        if (damage < 0)
        {
            damage = 0;
        }            
        CurrentHP -= damage;
    }

    private void Die()
    {
        Hero.GetResourceFromEnemy();
        Destroy(gameObject);
    }

  
    
}
