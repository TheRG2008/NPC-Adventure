using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private int _goldForRent;
    [SerializeField] private TypeLootResorce _typelootResorce;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _img;
    [Multiline(3)]
    [SerializeField] private string _discription;
    [SerializeField] private Equipment _startEquipment;
    private int _maxCountResorceCollect;

    public int TargetIndex;
    
    public int Level 
    { 
        get => _level; 
        set => _level = value; 
    }
    public int GoldForRent 
    { 
        get => _goldForRent; 
        set => _goldForRent = value; 
    }
    public TypeLootResorce TypelootResorce => _typelootResorce;
    public string Name => _name; 
    public Sprite Img => _img;
    public string Discription => _discription;
    public int MaxCountResorceCollect => _maxCountResorceCollect;
    public Equipment StartEquipment => _startEquipment;
  

    public void ChangeMaxCountResorceCollect()
    {
        switch (Level)
        {
            case 1:
                _maxCountResorceCollect = 10;
                _goldForRent = 50;
                break;
            case 2:
                _maxCountResorceCollect = 20;
                _goldForRent = 150;
                break;
            case 3:
                _maxCountResorceCollect = 30;
                _goldForRent = 300;
                break;
            case 4:
                _maxCountResorceCollect = 40;
                _goldForRent = 500;
                break;
            case 5:
                _maxCountResorceCollect = 50;
                _goldForRent = 1000;
                break;
        }
    }

   
}
