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

    #region signals dispatched (correct/win/lose)
    [Inject]
    public RoundCorrectSignal correctSignal {get; set; }

    [Inject]
    public RoundWonSignal wonSignal { get; set; }
    
    [Inject]
    public RoundLostSignal lostSignal { get; set; }
    
    [Inject]
    public RoundEndSignal endSignal { get; set; }
    #endregion
    
    public override void Execute()
    {
        // Debug.LogWarning($"[RoundAnswerCommand] Execution: ANum={AnswerNumber} AWea={round.ChoicesWeapons[AnswerNumber].Name} ");
        if (round.ChoicesWeapons[AnswerNumber] == round.CorrectChoice)
        {
            if (round.GetEnemiesQuantity() == 0)
            {
                Console.Log("RACmd","That was Last Phase!");
                endSignal.Dispatch();
                wonSignal.Dispatch();
                
                return;
            }
            Console.LogWarning("RACmd",$"Correct! Left phases = [{round.GetEnemiesQuantity()}]");
            correctSignal.Dispatch();
            return;
        }
        else
        {
            Console.LogWarning("RACmd","Incorrect!");
            endSignal.Dispatch();
            lostSignal.Dispatch(round.CorrectChoice);
            return;
        }
    }
}
