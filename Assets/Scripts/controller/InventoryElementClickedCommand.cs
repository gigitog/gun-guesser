using strange.extensions.command.impl;
using Util;

public class InventoryElementClickedCommand : Command
{
    [Inject]
    public IInventoryElement inventoryElementReceived { get; set; }
    public override void Execute()
    {
        // Execution
        
        // ExecutionDoneSignal.Dispatch();
    }
}