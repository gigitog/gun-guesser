using strange.extensions.mediation.impl;

/// <summary>
/// bounds relationship between <see cref="ProfileView"/> and rest of the App
/// </summary>
public class ProfileMediator : Mediator
{
    [Inject] public ProfileView view { get; set; }

    #region Dispatched Signals (BackToMenu)

    [Inject]
    public ProfileToMenuSignal profileToMenuSignal { get; set; }
    
    #endregion

    #region Listen To Signals (Profile Loaded)
    
    [Inject]
    public ProfileLoadedSignal profileLoadedSignal { get; set; }
    
    #endregion

    private void EnableView()
    {
        view.gameObject.SetActive(true);
    }

    private void DisableView()
    {
        view.gameObject.SetActive(false);
    }

    public override void OnRegister() => SetListeners(true);

    public override void OnRemove() => SetListeners(false);

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

