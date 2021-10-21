using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Saver
{
    private static string _data;

    public static void SaveData(string name, string data)
    {
        _data += $"{name}:{data};";
    }
    
    public static void SaveToFile(string path)
    {
        StreamWriter writer = new StreamWriter(path);
        writer.Write(_data);
        writer.Close();
    }
}

public static class Loader
{
    private static string[] _data;

    public static void LoadFromFile(string pathData)
    {
        _data = File.ReadAllText(pathData).Split(';');        
    }

    public static bool LoadData(string name, out string data)
    {
        for (int i = 0; i < _data.Length; i++)
        {
            if (_data[i].StartsWith(name))
            {
                data = _data[i].Split(':')[1];
                return true;
            }
        }

        data = null;
        return false;
    }
}

public class InventorySaver
{
    public void InventorySave(Inventory inventory)
    {
        Saver.SaveToFile(@"MySave.txt");
        Loader.LoadFromFile(@"MySave.txt");

        string itemsData = "";
        for (int i = 0; i < inventory.Items.Count; i++)
        {
            IItem item = inventory.GetItem(i);
            itemsData += $"{item.Name}|{item.Count}!";           
            
        }
        Saver.SaveData("Shop", itemsData);
    }

    public void InventoryLoad(Inventory inventory, string name)
    {
        if (Loader.LoadData("Shop", out string itemsData))
        {
            string[] items = itemsData.Split('!');
            for (int i = 0; i < items.Length; i++)
            {
                //inventory.AddItem
            }
        }
        
    }
}

