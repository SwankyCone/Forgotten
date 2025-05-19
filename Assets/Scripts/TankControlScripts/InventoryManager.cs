using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
   public static InventoryManager Instance;

    public List<AllItems> _InventoryItems = new List<AllItems>(); //ur inventory items

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(AllItems item) //add items to inventory 
    {
        if (!_InventoryItems.Contains(item))
        {
            _InventoryItems.Add(item);
        }
    }

    public void RemoveItem(AllItems item) //remove items from yo inventory 
    {
        if (_InventoryItems.Contains(item))
        {
            _InventoryItems.Remove(item);
        }
    }

    public enum AllItems //all available inventory items in game
    {
        KeyRed,
        KeyBlue,
        KeyGreen,
        KeyYellow,

    }



}
