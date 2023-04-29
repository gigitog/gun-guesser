
using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

/// <summary>
/// Process opening popup of Exit
/// </summary>
public class RoundShowExitCommand : Command
{
    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView{ get; set; }
    
    [Inject] 
    public GameObject exitPopupPrefab { get; set; }
    public override void Execute()
    {
        Console.LogError("RSECmd", "Spawn exitPopupView");
        GameObject exitPopupView = GameObject.Instantiate(exitPopupPrefab, contextView.transform);
        // exitPopupView.name = "ExitPopupView";
        // go.AddComponent<ExampleView>();
        // exitPopupView.transform.parent = contextView.transform;
    }
}
