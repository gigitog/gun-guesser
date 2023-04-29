using strange.extensions.mediation.impl;
using UnityEngine;

/// <summary>
/// Bounds relationship between <see cref="LoseView"/> and rest of the App
/// </summary>
public class LoseMediator : Mediator
{
    [Inject]
    public LoseView view { get; set; }
    
    #region Signals dispatched (again/menu)
    
    [Inject]
    public RoundToAgainSignal roundToAgainSignal { get; set; }
    
    [Inject]
    public RoundToMenuSignal menuLoadSignal { get; set; }
    
    #endregion

    #region Listen To Signals
    
    [Inject]
    public RoundLostSignal lostSignal { get; set; }
    
    #endregion
    
    public override void OnRegister()
    {
        base.OnRegister();
        SetListeners(true);
    }

    private void EnableView(IWeapon weapon)
    {
        SetLostDescription(weapon);
        view.gameObject.SetActive(true);
    }

    private void SetLostDescription(IWeapon weapon)
    {
        string description = $"It was better to use {weapon.Name}";
        view.LoseField = description;
    }

    private void DisableView() => view.gameObject.SetActive(false);

    // --- Listeners ---
    private void SetListeners(bool isSet)
    {
        if (isSet)
        {
            lostSignal.AddListener(EnableView);

            view.mainMenuCLickedSignal.AddListener(MainMenuClicked);
            view.againRoundClickedSignal.AddListener(NextRoundClicked);
        }
        else
        {
            lostSignal.RemoveListener(EnableView);
            
            
            view.mainMenuCLickedSignal.RemoveListener(MainMenuClicked);
            view.againRoundClickedSignal.RemoveListener(NextRoundClicked);
        }
    }

    private void NextRoundClicked()
    {
        Console.Log("LoseMediator", "Next Round clicked");
        roundToAgainSignal.Dispatch();
        DisableView();
    }

    private void MainMenuClicked()
    {
        Console.Log("LoseMediator", "Main Menu clicked");
        menuLoadSignal.Dispatch();
        DisableView();
    }

    public override void OnRemove() => SetListeners(false);
}
