
using strange.extensions.mediation.impl;
using UnityEngine;

/// <summary>
/// Bounds relationship between <see cref="ExitPopupView"/> and rest of the App
/// <remarks>ExitPopupView is destroyed</remarks>
/// </summary>
public class ExitPopupMediator : Mediator
{
    [Inject] 
    public ExitPopupView view { get; set; }
    
    [Inject] // Dispatch
    public RoundExitConfirmedSignal exitConfirmedSignal { get; set; }
    
    [Inject]
    public RoundExitCanceledSignal exitCanceledSignal { get; set; }
    
    [Inject]
    public RoundShowExitSignal showExitSignal { get; set; }

    private void ExitConfirmed(bool isConfirmed)
    {
        DisableView();
        if (isConfirmed) exitConfirmedSignal.Dispatch();
        else exitCanceledSignal.Dispatch();
    }
    private void EnableView(GameObject obj)
    {
        view.SetActive(true);
    }

    private void DisableView()
    {
        Destroy(view.gameObject);
    }

    // --- Listeners ---
    private void SetListeners(bool isSet)
    {
        if (isSet)
        {
            view.exitConfirmed.AddListener(ExitConfirmed);
            
            showExitSignal.AddListener(EnableView);
        }
        else
        {
            view.exitConfirmed.RemoveListener(ExitConfirmed);
            
            showExitSignal.RemoveListener(EnableView);
        }
    }

    public override void OnRegister()
    {
        view.SetActive(true);
        SetListeners(true);
    }

    public override void OnRemove() => SetListeners(false);
}
