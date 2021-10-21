using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public interface IItem 
{
    int MinCount { get; }
    int Count { get; set; }
    int MaxCount { get; set; }
    string Name { get; }
    string Description { get; }
    int Price { get; }
    int ID { get;}
    TypeResorce TypeResorce { get; }
    TypeItem TypeItem { get; }
    Sprite Img { get; }
   

}
