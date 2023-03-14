
using System.Collections.Generic;

public class InventoryModel : IInventory
{
    [Inject]
    public List<IInventoryElement> inventoryList { get; set; }
        
    public List<IInventoryElement> GetInventoryList()
    {
        return inventoryList;
    }
}
