
using System.Collections.Generic;

public interface IInventory
{
    public List<IInventoryElement> inventoryList { get; set; }
    public List<IInventoryElement> GetInventoryList();
}
