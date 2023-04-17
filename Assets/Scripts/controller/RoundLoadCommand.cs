using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

/// <summary>
/// Loads <see cref="IRound"/> bzw. gets information about its filling from game,
/// sets Enemies for it and dispatches <see cref="RoundLoadedSignal"/>
/// 
/// </summary>
public class RoundLoadCommand : Command
{
    // [Inject]
    // public IGameConfig gameConfig { get; set; }
    
    [Inject]
    public IGameRules gameRules { get; set; }

    [Inject] 
    public IUser user { get; set; }

    [Inject] 
    public RoundLoadedSignal roundLoadedSignal { get; set; }

    [Inject]
    public IRound round { get; set; }
    
    public override void Execute()
    {
        round.SetDefaultRound(gameRules.GetEnemiesForRound(), gameRules.GetTimeForRound(), gameRules.GetChoicesQuantityForRound());

        roundLoadedSignal.Dispatch();
    }
}

class RoundLoadCommand_Debug : RoundLoadCommand
{
    public override void Execute()
    {
        Debug.LogWarning("[RoundLoadCommand] Execution");
        base.Execute();
        Debug.Log($"[RLCmd] User: {user.Name}");
        Debug.Log($"[RLCmd] Inventory: {user.inventory.GetInventoryString()}");
        Debug.Log($"[RLCmd] Round:\n" +
                  $" - isPlaying: {round.IsPlaying}\n" +
                  $" - enemiesQ: {round.GetEnemiesQuantity()}");
    }
}