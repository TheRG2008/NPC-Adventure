using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemTest : MonoBehaviour
{
    public ScriptableObject[] Items;
    public Inventory Inventory;

    public void AddItemButton()
    {
        int rand = Random.Range(0, Items.Length);
        Inventory.AddItem(Items[rand] as IItem);
    }
}
