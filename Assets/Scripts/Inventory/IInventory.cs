using System.Collections;
using System.Collections.Generic;


public interface IInventory 
{    
    int Size { get; }
    IItem GetItem(int index);
    T GetItem<T>(int index) where T : IItem;
    bool CheckItem(IItem item);
    bool AddItem(IItem item, int count);
    bool RemoveItem(IItem item);
}
