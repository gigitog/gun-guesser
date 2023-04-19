using strange.extensions.mediation.impl;
using UnityEngine;

public class WinMediator : Mediator
{
    [Inject]
    public WinView view { get; set; }
    
    #region Signals dispatched (next/menu)
    
    [Inject]
    public RoundToNextSignal roundToNextSignal { get; set; }
    
    [Inject]
    public RoundToMenuSignal menuLoadSignal { get; set; }
    
    #endregion

    #region Listen To Signals
    
    [Inject]
    public RoundWonSignal wonSignal { get; set; }
    
    #endregion
    
    public override void OnRegister()
    {
        base.OnRegister();
        SetListeners(true);
    }

    private void EnableView() => view.gameObject.SetActive(true);

    private void DisableView() => view.gameObject.SetActive(false);

    // --- Listeners ---
    private void SetListeners(bool isSet)
    {
        if (isSet)
        {
            wonSignal.AddListener(EnableView);

            view.mainMenuCLickedSignal.AddListener(MainMenuClicked);
            view.nextRoundClickedSignal.AddListener(NextRoundClicked);
        }
        else
        {
            wonSignal.RemoveListener(EnableView);
            
            
            view.mainMenuCLickedSignal.RemoveListener(MainMenuClicked);
            view.nextRoundClickedSignal.RemoveListener(NextRoundClicked);
        }
    }

    private void NextRoundClicked()
    {
        Console.Log("WinMediator", "Next Round clicked");
        roundToNextSignal.Dispatch();
        DisableView();
    }

    private void MainMenuClicked()
    {
        Console.Log("WinMediator", "Main Menu clicked");
        menuLoadSignal.Dispatch();
        DisableView();
    }

    public override void OnRemove() => SetListeners(false);    
}
