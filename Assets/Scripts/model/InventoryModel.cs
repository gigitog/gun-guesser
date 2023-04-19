
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryModel : IInventory
{
    public List<IInventoryElement> inventoryList { get; set; }
    public List<IInventoryElement> alliesList => inventoryList.Where(element => element.weapon.Side == WeaponSide.Ally).ToList();
    public List<IInventoryElement> enemiesList => inventoryList.Where(element => element.weapon.Side == WeaponSide.Enemy).ToList();

    public void AddWeaponToInventory(IWeapon newWeapon)
    {
        foreach (var element in inventoryList)
        {
            if (element.weapon == newWeapon)
            {
                Console.LogWarning("InventoryModel","This weapon already exists in this Inventory");
                return;
            }
        }
        IInventoryElement inventoryElement = new IInventoryElement
        {
            weapon = newWeapon
        };
        
        inventoryList.Add(inventoryElement);
    }

    public IInventoryElement Get()
    {
        throw new System.NotImplementedException();
    }

    public string GetInventoryString()
    {
        string result = "";
        int counter = 0;
        foreach (var element in inventoryList)
        {
            counter++;
            var side = element.weapon.Side == WeaponSide.Ally ? "A" : "E";
            result += $"{counter} : {side} {element.weapon.Name}\n";
        }

        return result;
    }
}
