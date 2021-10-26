using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ecuipment", menuName = "NewItem/Ecuipment", order = 51)]
public class Equipment : ScriptableObject, IItem
{
    [SerializeField] private int _count;
    [SerializeField] private TypeResorce _typeResorce;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _img;
    [SerializeField] private int _damage;
    [SerializeField] private int _defence;
    [SerializeField] private float _hpResurection;
    [SerializeField] private float _spResurection;    
    [SerializeField] private int _price;
    [SerializeField] private float _hp;
    [SerializeField] private float _sp;
    [SerializeField] private int _weight;    
    private TypeItem _typeItem = TypeItem.Equipment;
    private int _id;


    public int Count
    {
        get => _count;
        set 
        {
            _count = value;
            if (_count <= 0)
            {
                _count = 0;
            }
        }
    }
    
    public TypeResorce TypeResorce => _typeResorce;
    public string Name => _name;
    public string Description => _description;
    public Sprite Img => _img;
    public int ID => _id;
    public int Damage => _damage;
    public int Defence => _defence;
    public float HpResurection => _hpResurection;
    public float SpResurection => _spResurection;
    public TypeItem TypeItem => _typeItem;
    
    public int Price => _price;
    public float Hp => _hp;
    public float Sp => _sp;
    public int Weight => _weight;

    public TypeLootResorce TypeLoot => throw new System.NotImplementedException();

    public IItem Copy()
    {
        throw new System.NotImplementedException();
    }

    public IItem GiveResource(int count)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveItem(int count)
    {
        
    }

    int IItem.RemoveItem(int count)
    {
        throw new System.NotImplementedException();
    }
}
