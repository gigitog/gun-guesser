
using System;
using strange.extensions.mediation.impl;
using strange.extensions.signal.api;

public class MenuMediator : Mediator
{
    [Inject]
    public MenuView view{ get; set;}
    
    #region Dispatched Signals
    

    #endregion

    #region Listen To Signals
    
    

    #endregion
    
    public override void OnRegister()
    {
        view.MenuCardClickedSignal.AddListener(null);
        view.MenuInventoryClickedSignal.AddListener(null);
        view.MenuProfileClickedSignal.AddListener(null);
        view.StartClickedSignal.AddListener(null);
    }

    public override void OnRemove()
    {
        view.MenuCardClickedSignal.RemoveListener(null);
        view.MenuInventoryClickedSignal.RemoveListener(null);
        view.MenuProfileClickedSignal.RemoveListener(null);
        view.StartClickedSignal.RemoveListener(null);
    }
}
