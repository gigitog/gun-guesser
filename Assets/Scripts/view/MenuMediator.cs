
using System;
using strange.extensions.mediation.impl;
using strange.extensions.signal.api;
using UnityEngine;

public class MenuMediator : Mediator
{
    [Inject]
    public MenuView view{ get; set;}

    [Inject]
    public MenuStartRoundSignal startRoundSignal { get; set; }
    
    #region Dispatched Signals
    

    #endregion

    #region Listen To Signals
    
    

    #endregion
    
    public override void OnRegister()
    {
        SetListeners(true);
    }

    private void OnStartButtonClicked()
    {
        Debug.Log("Menu mediator: Start Clicked");
        startRoundSignal.Dispatch();
    }

    private void OnInventoryButtonClicked()
    {
        Debug.Log("Menu mediator: Inventory Clicked");
    }

    private void OnProfileButtonClicked()
    {
        Debug.Log("Menu mediator: Profile Clicked");
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
