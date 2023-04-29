using strange.extensions.mediation.impl;

/// <summary>
/// bounds relationship between <see cref="MenuCardView"/> and rest of the App
/// </summary>
public class MenuCardMediator : Mediator
{
    [Inject] 
    public MenuCardView view { get; set; }
    
    [Inject]
    public MenuCardClickedSignal menuCardClickedSignal{ get; set;}
    
    [Inject]
    public MenuCardChangedSignal menuCardChangedSignal { get; set; }

    [Inject]
    public IGameConfig gameConfig { get; set; }
    
    public override void OnRegister()
    {
        view.CardClickedSignal.AddListener(CardClicked);
        
        menuCardChangedSignal.AddListener(SetCard);
        
        CardClicked();
    }

    public override void OnRemove()
    {
        // Debug.LogWarning("Mediator Remove");
        view.CardClickedSignal.RemoveListener(CardClicked);
        
        menuCardChangedSignal.RemoveListener(SetCard);
    }

    private void CardClicked()
    {
        menuCardClickedSignal.Dispatch();
    }

    private void SetCard(IWeapon weapon)
    {
        view.SetCard(weapon, gameConfig);
    }
}
