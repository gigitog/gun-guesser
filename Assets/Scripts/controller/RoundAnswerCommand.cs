using strange.extensions.command.impl;
using UnityEngine;

/// <summary>
/// Executed when user answered for a phase. Correct answer leads to next Phase or to Win; Incorrect answer leads to Lose;
/// <seealso cref="Winning"/> <seealso cref="Losing"/>
/// </summary>
public class RoundAnswerCommand : Command
{
    [Inject]
    public int AnswerNumber { get; set; }
    
    [Inject]
    public IRound round { get; set; }
    
    [Inject]
    public IGameConfig gameConfig { get; set; }
    public override void Execute()
    {
        Debug.LogWarning($"[RoundAnswerCommand] Execution: ANum={AnswerNumber} AWea={round.ChoicesWeapons[AnswerNumber].Name} ");
    }
}
