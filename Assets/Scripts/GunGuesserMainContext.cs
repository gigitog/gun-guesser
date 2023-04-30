using strange.examples.signals;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;
using Util;

public class GunGuesserMainContext : MVCSContext
{
    public GunGuesserMainContext (MonoBehaviour view) : base(view) {}

    public GunGuesserMainContext (MonoBehaviour view, ContextStartupFlags flags) : base(view, flags) {}

    /// Model
    private void BindModels()
    {
        IGameConfig config = loadGameConfig();
        
        injectionBinder.Bind<IGameConfig>().ToValue(config);
        injectionBinder.Bind<IGameRules>().To<GameRulesModel>().ToSingleton();
        injectionBinder.Bind<IRound>().To<RoundModel>().ToSingleton();
        injectionBinder.Bind<IWeapon>().To<WeaponModel>();
        injectionBinder.Bind<IInventory>().To<InventoryModel>();
        injectionBinder.Bind<IInventoryElement>().To<InventoryElementModel>().ToName(StrangeInjectionNames.MODEL);
        injectionBinder.Bind<IUser>().To<UserModel>().ToSingleton();
    }

    /// User Interface
    private void BindViewsToMediators()
    {
        mediationBinder.BindView<MenuView>().To<MenuMediator>();
        mediationBinder.BindView<MenuCardView>().To<MenuCardMediator>();
        mediationBinder.BindView<RoundView>().To<RoundMediator>();
        mediationBinder.BindView<ExitPopupView>().To<ExitPopupMediator>();
        mediationBinder.BindView<WinView>().To<WinMediator>();
        mediationBinder.BindView<LoseView>().To<LoseMediator>();
        mediationBinder.BindView<ProfileView>().To<ProfileMediator>();
        mediationBinder.BindView<InventoryView>().To<InventoryMediator>();
        mediationBinder.BindView<InventoryElementView>().To<InventoryElementMediator>();
    }

    /// Menu Controllers
    private void BindMenuSignalsToCommands()
    {
        commandBinder.Bind<MenuLoadSignal>().To<MenuLoadCommand>();
        
        commandBinder.Bind<MenuCardClickedSignal>().To<MenuCardChangeCommand>();

        commandBinder.Bind<MenuInventoryLoadSignal>().To<InventoryLoadCommand>();
        commandBinder.Bind<InventoryElementClickedSignal>().To<InventoryElementClickedCommand>();

        commandBinder.Bind<MenuProfileLoadSignal>().To<ProfileLoadCommand>();
        
        commandBinder.Bind<ProfileToMenuSignal>().To<MenuLoadCommand>();
        commandBinder.Bind<InventoryToMenuSignal>().To<MenuLoadCommand>();
    }
    /// Round Controllers
    private void BindRoundSignalsToCommands()
    {
        
        commandBinder.Bind<RoundToMenuSignal>().To<MenuLoadCommand>();

        commandBinder.Bind<RoundToNextSignal>().To<RoundLoadCommand>();
        commandBinder.Bind<RoundToAgainSignal>().To<RoundLoadCommand>();
        commandBinder.Bind<MenuStartRoundSignal>().To<RoundLoadCommand>();

        commandBinder.Bind<RoundShowExitSignal>().To<RoundShowExitCommand>();
        commandBinder.Bind<RoundExitConfirmedSignal>().To<RoundExitConfirmedCommand>();

        commandBinder.Bind<RoundGetPhaseSignal>().To<RoundGetPhaseCommand_Debug>();
        commandBinder.Bind<RoundAnsweredSignal>().To<RoundAnswerCommand>();

        commandBinder.Bind<CallWebServiceSignal>().To<CallWebServiceCommand>();

        
    }

    /// Signals which are dispatched inside Commands (Controllers)
    private void InjectSignalsAsSingleton()
    {
        injectionBinder.Bind<MenuCardChangedSignal>().ToSingleton();
        injectionBinder.Bind<MenuLoadedSignal>().ToSingleton();
        injectionBinder.Bind<ProfileLoadedSignal>().ToSingleton();
        injectionBinder.Bind<InventoryLoadedSignal>().ToSingleton();
        injectionBinder.Bind<RoundLoadedSignal>().ToSingleton();
        injectionBinder.Bind<RoundPhaseLoadedSignal>().ToSingleton();
        injectionBinder.Bind<RoundEndSignal>().ToSingleton();
        injectionBinder.Bind<RoundWonSignal>().ToSingleton();
        injectionBinder.Bind<RoundLostSignal>().ToSingleton();
        injectionBinder.Bind<RoundCorrectSignal>().ToSingleton();
        injectionBinder.Bind<RoundExitCanceledSignal>().ToSingleton();
    }

    protected override void mapBindings()
    {
        injectionBinder.Bind<IExampleService>().To<ExampleService>().ToSingleton();

        // --- Models ---
        BindModels();
        
        BindViewsToMediators();
        
        BindMenuSignalsToCommands();
        BindRoundSignalsToCommands();

        //Note how we've bound it "Once". This means that the mapping goes away as soon as the command fires.
        commandBinder.Bind<GGStartSignal>().To<StartCommand>().Once();
        
        InjectSignalsAsSingleton();
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
        GGStartSignal startSignal = injectionBinder.GetInstance<GGStartSignal>();
        startSignal.Dispatch();
        return this;
    }

    private IGameConfig loadGameConfig()
    {
        var config = Resources.Load<GameConfigScriptableObject>("GameConfig");
        return config;
    }
}
