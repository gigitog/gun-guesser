using strange.extensions.command.impl;
using UnityEngine;
/// <summary>
/// Process opening of the Inventory
/// </summary>
public class InventoryLoadCommand : Command
{
    [Inject]
    public InventoryLoadedSignal inventoryLoadedSignal { get; set; }
    public override void Execute()
    {
        // Execution
        Console.Log("ILCmd", "Execution");
        inventoryLoadedSignal.Dispatch();
    }
}