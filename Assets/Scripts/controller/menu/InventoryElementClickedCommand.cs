using strange.extensions.command.impl;

/// <summary>
/// Process opening of Inventory Element
/// </summary>
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