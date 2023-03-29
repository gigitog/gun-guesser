using strange.extensions.command.impl;
using UnityEngine;

public class RoundLoadCommand : Command
{
    [Inject]
    public IGameConfig gameConfig { get; set; }

    [Inject] 
    public RoundLoadedSignal roundLoadedSignal { get; set; }
    
    public override void Execute()
    {
        
    }
}