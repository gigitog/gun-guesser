
using System.Collections.Generic;

public class InventoryModel : IInventory
{
    public List<InventoryObjectModel> inventoryList;
        
    public List<InventoryObjectModel> GetInventoryList()
    {
        return inventoryList;
    }
}
