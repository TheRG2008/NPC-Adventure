using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour, IItem
{
    [SerializeField] private int _count;
    [SerializeField] private TypeResorce _typeResorce;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _img;    
    [SerializeField] private int _price;    
    [SerializeField] private TypeLootResorce _typeLoot;
    private TypeItem _typeItem = TypeItem.Resourse;
    private int _id;



    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            if (_count <= 0)
            {
                DestroyResourse();
                _count = 0;
            }
        }
    }
    
    public TypeResorce TypeResorce => _typeResorce;
    public string Name => _name;
    public string Description => _description;
    public Sprite Img => _img;
    public int ID => _id;

    public TypeItem TypeItem => _typeItem;
   
    public int Price => _price;

    public TypeLootResorce TypeLoot => _typeLoot;   

    public int RemoveItem (int count)
    {
        if (count > _count)
        {
            count = _count;
            Count = 0;
            return count;
           
        }
        _count -= count;
        return count;
    }

    public void DestroyResourse ()
    {
        Destroy(gameObject);
    }

    public IItem Copy()
    {
       Resource resource = new Resource();
        resource.Count = _count;
        resource._typeResorce = _typeResorce;
        resource._name = _name;
        resource._description = _description;
        resource._img = _img;
        resource._price = _price;
        resource._typeLoot = _typeLoot;
        resource._typeItem = _typeItem;
        resource._id = _id;

        return resource;        
    }
}
