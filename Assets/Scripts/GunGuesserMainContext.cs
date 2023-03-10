
using strange.examples.signals;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

public class GunGuesserMainContext: MVCSContext
{
    public GunGuesserMainContext (MonoBehaviour view) : base(view)
    {
    }

    public GunGuesserMainContext (MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
    {
    }
	
    // Unbind the default EventCommandBinder and rebind the SignalCommandBinder
    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }
	
    // Override Start so that we can fire the StartSignal 
    public override IContext Start()
    {
        base.Start();
        GGStartSignal startSignal = (GGStartSignal)injectionBinder.GetInstance<GGStartSignal>();
        startSignal.Dispatch();
        return this;
    }
	
    protected override void mapBindings()
    {
        injectionBinder.Bind<UserModel>().To<UserModel>().ToSingleton();
        injectionBinder.Bind<RoundModel>().To<RoundModel>().ToSingleton();
        injectionBinder.Bind<IWeapon>().To<WeaponModel>();
        
        injectionBinder.Bind<IExampleService>().To<ExampleService>().ToSingleton();
		

        mediationBinder.Bind<MenuView>().To<MenuMediator>();
        
        // --- Commands ---
        commandBinder.Bind<MenuCardChangedSignal>().To<MenuChangeCardCommand>();
        
        commandBinder.Bind<CallWebServiceSignal>().To<CallWebServiceCommand>();
		
        //StartSignal is now fired instead of the START event.
        //Note how we've bound it "Once". This means that the mapping goes away as soon as the command fires.
        commandBinder.Bind<GGStartSignal>().To<StartCommand>().Once ();
        
        // --- Signals ---
        injectionBinder.Bind<CardChangedSignal>().ToSingleton();
        
        injectionBinder.Bind<ScoreChangedSignal>().ToSingleton();
        injectionBinder.Bind<FulfillWebServiceRequestSignal>().ToSingleton();
    }
    
}
