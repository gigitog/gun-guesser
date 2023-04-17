
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

/// <summary>
/// Executed after loading round or user answer.
/// Gets choices for Enemy depending on <see cref="IGameConfig"/>, <see cref="IGameRules"/>
/// and dispatches <see cref="RoundPhaseLoadedSignal"/>
/// </summary>
public class RoundGetPhaseCommand : Command
{
    [Inject]
    public IGameRules gameRules { get; set; }
    
    [Inject] 
    public IUser user { get; set; }

    [Inject] 
    public RoundPhaseLoadedSignal phaseLoadedSignal { get; set; }

    [Inject]
    public IRound round { get; set; }
    
    public override void Execute()
    {
        IWeapon enemy = GetEnemyForPhase(round);

        for (int i = 0; i < gameRules.GetChoicesQuantityForRound(); i++)
        {
            round.SetChoice(i+1, enemy);
        }

        phaseLoadedSignal.Dispatch(enemy, round.ChoicesWeapons); // TODO add allies for choices
    }

    private IWeapon GetEnemyForPhase(IRound r)
    {
        return r.GetNextEnemy();
    }

    private (IWeapon, IWeapon) GetChoices(IRound r, IInventory inventory)
    {
        (IWeapon, IWeapon) tuple = (null, null);

        // weaponConfig.GetWeapons();

    
        return tuple;
    }
    
    
}

class RoundGetPhaseCommand_Debug : RoundGetPhaseCommand
{
    public override void Execute()
    {
        Debug.LogWarning("[RGPCmd] Execution");
        base.Execute();
    }
}
