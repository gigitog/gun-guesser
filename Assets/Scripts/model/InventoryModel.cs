
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel : IInventory
{
    public List<IInventoryElement> inventoryList { get; set; }

    public void AddWeaponToInventory(IWeapon newWeapon)
    {
        foreach (var element in inventoryList)
        {
            if (element.weapon == newWeapon)
            {
                Debug.Log("This weapon already exists in this Inventory");
                return;
            }
        }
        IInventoryElement inventoryElement = new IInventoryElement
        {
            weapon = newWeapon
        };
        
        inventoryList.Add(inventoryElement);
    }
}
