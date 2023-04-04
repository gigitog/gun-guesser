using strange.extensions.command.impl;
using UnityEngine;

public class RoundAnswerCommand : Command
{
    [Inject]
    public int AnswerNumber { get; set; }
    
    [Inject]
    public IRound roundModel { get; set; }
    
    [Inject]
    public IGameConfig gameConfig { get; set; }
    public override void Execute()
    {
        Debug.LogWarning($"Round Answer Command Execution: A={AnswerNumber}");
    }
}
