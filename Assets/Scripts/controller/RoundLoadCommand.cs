using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class RoundLoadCommand : Command
{
    [Inject]
    public IGameConfig gameConfig { get; set; }

    [Inject] 
    public IUser user { get; set; }

    [Inject] 
    public RoundLoadedSignal roundLoadedSignal { get; set; }

    [Inject]
    public IRound round { get; set; }
    
    public override void Execute()
    {
        Debug.LogWarning("[RoundLoadCommand] Execution");
        
        Debug.Log($"[RLC] User: {user.Name}");
        Debug.Log($"[RLC] Inventory: {user.inventory.GetInventoryString()}");
        
        SetEnemiesForRound();
        roundLoadedSignal.Dispatch();
    }

    private void SetEnemiesForRound()
    {
        round.SetPhases(GetPhases());
    }

    private List<IWeapon> GetPhases()
    {
        return gameConfig.GetEnemiesForRound(user);
    }
}