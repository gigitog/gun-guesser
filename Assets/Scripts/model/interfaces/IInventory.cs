
using System.Collections.Generic;

public interface IInventory
{
    public List<IInventoryElement> inventoryList { get; set; }

    public void AddWeaponToInventory(IWeapon newWeapon);
}
