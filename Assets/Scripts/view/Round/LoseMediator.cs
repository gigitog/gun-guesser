
using strange.extensions.mediation.impl;

public class LoseMediator : Mediator
{
    [Inject]
    public LoseView view { get; set; }
    
    #region Signals dispatched (again/menu)
    
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

    // --- Listeners ---
    private void SetListeners(bool isSet)
    {
        // if (isSet)
        // {
        //     loadedSignal.AddListener(SetRound);
        //     phaseLoadedSignal.AddListener(SetPhase);
        //     wonSignal.AddListener(ShowWinningScreen);
        //     lostSignal.AddListener(ShowLosingScreen);
        //     correctSignal.AddListener(ShowAnimationOfCorrect);
        //     
        //     view.exitClickedSignal.AddListener(ShowExitConfirmPopup);
        //     view.choiceClickedSignal.AddListener(AnswerClicked);
        // }
        // else
        // {
        //     loadedSignal.RemoveListener(SetRound);
        //     phaseLoadedSignal.RemoveListener(SetPhase);
        //     wonSignal.RemoveListener(ShowWinningScreen);
        //     lostSignal.RemoveListener(ShowLosingScreen);
        //     correctSignal.RemoveListener(ShowAnimationOfCorrect);
        //     
        //     view.exitClickedSignal.RemoveListener(ShowExitConfirmPopup);
        //     view.choiceClickedSignal.RemoveListener(AnswerClicked);
        // }
    }

    public override void OnRemove() => SetListeners(false);    
}
