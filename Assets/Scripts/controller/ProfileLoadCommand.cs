using strange.extensions.command.impl;
using UnityEngine;

public class ProfileLoadCommand : Command
{
    [Inject]
    public ProfileLoadedSignal profileLoadedSignal { get; set; }
    public override void Execute()
    {
        Console.Log("PLCmd", "Execution");
        // Execution
        
        profileLoadedSignal.Dispatch();
    }
}