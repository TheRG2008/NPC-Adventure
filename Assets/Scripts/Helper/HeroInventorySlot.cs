using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInventorySlot : MonoBehaviour
{
    [SerializeField] private TypeResorce _typeResorce;

    public TypeResorce TypeResorce => _typeResorce;
}
