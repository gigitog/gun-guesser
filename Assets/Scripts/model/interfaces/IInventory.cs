
using System.Collections.Generic;

public interface IInventory
{
    public List<IInventoryElement> inventoryList { get; set; }
    public List<IInventoryElement> alliesList { get; }
    public List<IInventoryElement> enemiesList { get; }

    public void AddWeaponToInventory(IWeapon newWeapon);
    public string GetInventoryString();

}
