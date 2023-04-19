using strange.extensions.mediation.impl;
using Console = UnityEngine.Console;

public class MenuMediator : Mediator
{
    [Inject]
    public MenuView view{ get; set;}

    #region Dispatched Signals
    [Inject]
    public MenuStartRoundSignal startRoundSignal { get; set; }
    #endregion

    #region Listen To Signals (Menu Loaded, Round Loaded)
    
    [Inject]
    public MenuLoadedSignal menuLoadedSignal { get; set; }
    
    [Inject]
    public RoundLoadedSignal roundLoadedSignal { get; set; }

    #endregion
    
    public override void OnRegister()
    {
        SetListeners(true);
    }

    private void OnStartButtonClicked()
    {
        Console.Log("MenuMediator", "Start Clicked");
        startRoundSignal.Dispatch();
    }

    private void OnInventoryButtonClicked()
    {
        Console.Log("MenuMediator","Inventory Clicked");
    }

    private void OnProfileButtonClicked()
    {
        Console.Log("MenuMediator","Profile Clicked");
    }

    public override void OnRemove()
    {
        SetListeners(false);
    }
    
    private void SetListeners(bool isSet)
    {
        if (isSet)
        {
            menuLoadedSignal.AddListener(EnableView);
            roundLoadedSignal.AddListener(DisableView);
            
            view.MenuInventoryClickedSignal.AddListener(OnInventoryButtonClicked);
            view.MenuProfileClickedSignal.AddListener(OnProfileButtonClicked);
            view.MenuStartClickedSignal.AddListener(OnStartButtonClicked);
        }
        else
        {
            menuLoadedSignal.RemoveListener(EnableView);
            roundLoadedSignal.RemoveListener(DisableView);
            
            view.MenuInventoryClickedSignal.RemoveListener(OnInventoryButtonClicked);
            view.MenuProfileClickedSignal.RemoveListener(OnProfileButtonClicked);
            view.MenuStartClickedSignal.RemoveListener(OnStartButtonClicked);
        }
    }

    private void EnableView()
    {
        Console.Log("MenuMediator", "Enable View");
        view.gameObject.SetActive(true);
    }

    private void DisableView()
    {
        view.gameObject.SetActive(false);
    }
}
