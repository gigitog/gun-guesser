
using System.Collections.Generic;

/// <summary>
/// Inventory of <see cref="IUser"/> which stores information of Allies and Enemies Lists of available <see cref="IWeapon"/>.
/// </summary>
public interface IInventory
{
    public List<IInventoryElement> inventoryList { get; set; }
    public List<IInventoryElement> alliesList { get; }
    public List<IInventoryElement> enemiesList { get; }

    public void AddWeaponToInventory(IWeapon newWeapon);
    // public IInventoryElement Get
    public string GetInventoryString();
}
