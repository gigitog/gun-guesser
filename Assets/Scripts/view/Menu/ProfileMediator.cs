using System;
using strange.extensions.mediation.impl;

public class ProfileMediator : Mediator
{
    [Inject] public ProfileView view { get; set; }

    #region Dispatched Signals

    #endregion

    #region Listen To Signals
    [Inject]
    public ProfileLoadedSignal profileLoadedSignal { get; set; }
    #endregion

    private void EnableView()
    {
        view.gameObject.SetActive(true);
    }

    private void DisableView()
    {
        throw new NotImplementedException();
    }

    public override void OnRegister()
    {
        SetListeners(true);
    }

    public override void OnRemove()
    {
        SetListeners(false);
    }

    private void SetListeners(bool isSet)
    {
        if (isSet)
        {
            // Add Listeners
            profileLoadedSignal.AddListener(EnableView);
        }
        else
        {
            // Remove Listeners
            profileLoadedSignal.RemoveListener(EnableView);
        }
    }

    
}

