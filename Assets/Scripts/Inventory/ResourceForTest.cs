using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resource", menuName = "NewItem/Resourse", order = 51)]
public class ResourceForTest : ScriptableObject, IItem
{
    [SerializeField] private int _count;
    [SerializeField] private TypeResorce _typeResorce;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _img;
    [SerializeField] private int _maxCount;
    [SerializeField] private int _price;
    private TypeItem _typeItem = TypeItem.Resourse;
    private int _id;

    [SerializeField] private int _minCount;
    
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
    public int MaxCount 
    { 
        get => _maxCount; 
        set => _maxCount = value; 
    }
    public TypeResorce TypeResorce => _typeResorce;   
    public string Name  => _name;
    public string Description => _description;
    public Sprite Img => _img;
    public int ID => _id;

    public TypeItem TypeItem => _typeItem;
    public int MinCount => _minCount;
    public int Price => _price;
}
