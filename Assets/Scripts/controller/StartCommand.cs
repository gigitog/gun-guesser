using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

public class StartCommand : Command
{
	
    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView{get;set;}
	
    public override void Execute()
    {
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
