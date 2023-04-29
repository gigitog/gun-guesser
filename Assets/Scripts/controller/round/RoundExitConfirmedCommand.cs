
using strange.extensions.command.impl;
using UnityEngine;

/// <summary>
/// Process leaving round
/// </summary>
public class RoundExitConfirmedCommand : Command
{
    [Inject]
    public RoundEndSignal endSignal{ get; set; }
    
    [Inject]
    public IRound round { get; set; }
    
    [Inject]
    public MenuLoadSignal menuLoadSignal { get; set; }
    
    public override void Execute()
    {
        //exit round
        round.CleanRound();
        endSignal.Dispatch();
        menuLoadSignal.Dispatch();
    }
}
