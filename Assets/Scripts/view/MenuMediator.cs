
using System;
using strange.extensions.mediation.impl;
using UnityEngine;
using Console = UnityEngine.Console;

public class MenuMediator : Mediator
{
    [Inject]
    public MenuView view{ get; set;}

    #region Dispatched Signals
    [Inject]
    public MenuStartRoundSignal startRoundSignal { get; set; }
    #endregion

    #region Listen To Signals
    
    

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
            view.MenuInventoryClickedSignal.AddListener(OnInventoryButtonClicked);
            view.MenuProfileClickedSignal.AddListener(OnProfileButtonClicked);
            view.MenuStartClickedSignal.AddListener(OnStartButtonClicked);
        }
        else
        {
            view.MenuInventoryClickedSignal.RemoveListener(OnInventoryButtonClicked);
            view.MenuProfileClickedSignal.RemoveListener(OnProfileButtonClicked);
            view.MenuStartClickedSignal.RemoveListener(OnStartButtonClicked);
        }
    }
}
