
using strange.extensions.command.impl;
using UnityEngine;

public class RoundGetPhaseCommand : Command
{
    [Inject]
    public IGameConfig gameConfig { get; set; }

    [Inject] 
    public IUser user { get; set; }

    [Inject] 
    public RoundPhaseLoadedSignal phaseLoadedSignal { get; set; }

    [Inject]
    public IRound round { get; set; }
    public override void Execute()
    {
        Debug.LogWarning("[RoundGetPhaseCommand] Execution");



        // phaseLoadedSignal.Dispatch(object, object, object);
    }
}
