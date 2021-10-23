using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public interface IItem 
{    
    int Count { get; set; }   
    string Name { get; }
    string Description { get; }
    int Price { get; }
    int ID { get;}
    TypeLootResorce TypeLoot { get; }
    TypeResorce TypeResorce { get; }
    TypeItem TypeItem { get; }
    Sprite Img { get; }
    public void RemoveItem(int count);
    

}
