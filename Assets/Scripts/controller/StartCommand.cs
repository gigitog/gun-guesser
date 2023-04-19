using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

/// <summary>
/// Command is executed on the "start" of the app 
/// </summary>
public class StartCommand : Command
{
	
    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView{get;set;}
    
    [Inject]
    public IGameConfig gameConfig { get; set; }
    
    [Inject]
    public MenuLoadSignal menuLoadSignal { get; set; }
    public override void Execute()
    {
        menuLoadSignal.Dispatch();
        // CreateUser();
        //TODO 
        // Load assets
        // Load User
        // Load Firebase?

        // GameObject go = new GameObject();
        // go.name = "ExampleView";
        // // go.AddComponent<ExampleView>();
        // go.transform.parent = contextView.transform;
    }

    
}
