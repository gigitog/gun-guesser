using strange.extensions.command.impl;
using UnityEngine;

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