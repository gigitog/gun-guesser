
using strange.extensions.command.impl;
using UnityEngine;

/// <summary>
/// Process opening of the Menu
/// </summary>
public class MenuLoadCommand : Command
{
    [Inject]
    public MenuLoadedSignal menuLoadedSignal { get; set; }
    public override void Execute()
    {
        Console.LogWarning("MLCmd", "Execution");
        menuLoadedSignal.Dispatch();
    }
}
