using strange.examples.signals;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

public class GunGuesserMainContext : MVCSContext
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
        IGameConfig config = loadGameConfig();
        
        // --- Models ---
        injectionBinder.Bind<IGameConfig>().ToValue(config);
        injectionBinder.Bind<IGameRules>().To<GameRulesModel>().ToSingleton();
        injectionBinder.Bind<IRound>().To<RoundModel>().ToSingleton();
        injectionBinder.Bind<IWeapon>().To<WeaponModel>();
        injectionBinder.Bind<IInventory>().To<InventoryModel>();
        injectionBinder.Bind<IInventoryElement>().To<InventoryElementModel>();
        injectionBinder.Bind<IUser>().To<UserModel>().ToSingleton();

        // ---
        
        injectionBinder.Bind<IExampleService>().To<ExampleService>().ToSingleton();

        // --- View Mediators ---
        mediationBinder.Bind<MenuView>().To<MenuMediator>();
        mediationBinder.Bind<MenuCardView>().To<MenuCardMediator>();
        mediationBinder.Bind<RoundView>().To<RoundMediator>();
        mediationBinder.Bind<ExitPopupView>().To<ExitPopupMediator>();
        mediationBinder.Bind<WinView>().To<WinMediator>();
        mediationBinder.Bind<LoseView>().To<LoseMediator>();
        
        // --- Commands ---
        // --- --- Menu:
        commandBinder.Bind<MenuCardClickedSignal>().To<MenuChangeCardCommand>();

        // --- --- Round:
        commandBinder.Bind<MenuLoadSignal>().To<MenuLoadCommand>();
        commandBinder.Bind<RoundToMenuSignal>().To<MenuLoadCommand>();
        
        commandBinder.Bind<RoundToNextSignal>().To<RoundLoadCommand>();
        commandBinder.Bind<RoundToAgainSignal>().To<RoundLoadCommand>();
        commandBinder.Bind<MenuStartRoundSignal>().To<RoundLoadCommand>();

        commandBinder.Bind<RoundShowExitSignal>().To<RoundShowExitCommand>();
        commandBinder.Bind<RoundExitConfirmedSignal>().To<RoundExitConfirmedCommand>();

        commandBinder.Bind<RoundGetPhaseSignal>().To<RoundGetPhaseCommand_Debug>();
        commandBinder.Bind<RoundAnsweredSignal>().To<RoundAnswerCommand>();
        
        commandBinder.Bind<CallWebServiceSignal>().To<CallWebServiceCommand>();
		
        
        //Note how we've bound it "Once". This means that the mapping goes away as soon as the command fires.
        commandBinder.Bind<GGStartSignal>().To<StartCommand>().Once ();
        
        // --- Signals ---
        injectionBinder.Bind<MenuCardChangedSignal>().ToSingleton();
        
        // injectionBinder.Bind<RoundLoadedSignal>().ToSingleton();
        injectionBinder.Bind<MenuLoadedSignal>().ToSingleton();
        injectionBinder.Bind<RoundLoadedSignal>().ToSingleton();
        injectionBinder.Bind<RoundPhaseLoadedSignal>().ToSingleton();
        injectionBinder.Bind<RoundEndSignal>().ToSingleton();
        injectionBinder.Bind<RoundWonSignal>().ToSingleton();
        injectionBinder.Bind<RoundLostSignal>().ToSingleton();
        injectionBinder.Bind<RoundCorrectSignal>().ToSingleton();
        injectionBinder.Bind<RoundExitCanceledSignal>().ToSingleton();
    }

    private IGameConfig loadGameConfig()
    {
        var config = Resources.Load<GameConfigScriptableObject>("GameConfig");
        return config;
    }
}
