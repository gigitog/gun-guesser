
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

public class RoundMediator : Mediator
{
    //
    [Inject] 
    public RoundView view { get; set; }
    [Inject]
    public IGameConfig gameConfig { get; set; }
    
    // Signals
    [Inject]
    public RoundAnsweredSignal answeredSignal { get; set; }
    [Inject]
    public RoundCardLoadedSignal cardLoadedSignal { get; set; }
    [Inject]
    public RoundWonSignal wonSignal { get; set; }
    [Inject]
    public RoundLostSignal lostSignal { get; set; }
    [Inject]
    public RoundCorrectAnsweredSignal correctAnsweredSignal { get; set; }
    
    public override void OnRegister()
    {
        SetListeners(true);
    }
    
    private void FirstAnswerClicked() => answeredSignal.Dispatch(1);
    private void SecondAnswerClicked() => answeredSignal.Dispatch(2);

    private void SetPhase(IWeapon enemy, IWeapon firstWeapon, IWeapon secondWeapon)
    {
        SetEnemy(enemy);
        SetFirst(firstWeapon);
        SetSecond(secondWeapon);
    }

    #region Show UI Screens
    
    private void ShowExitConfirmPopup()
    {
        Debug.LogWarning("[RoundMediator] Show Exit");
        throw new System.NotImplementedException();
    }

    private void ShowAnimationCorrect(IWeapon obj)
    {
        Debug.LogWarning("[RoundMediator] Show Correct Answered Animation");
        throw new System.NotImplementedException();
    }

    private void ShowLosingScreen()
    {
        Debug.LogWarning("[RoundMediator] Show Lose");
        throw new System.NotImplementedException();
    }

    private void ShowWinningScreen()
    {
        Debug.LogWarning("[RoundMediator] Show Win");
        throw new System.NotImplementedException();
    }
    #endregion
    
    #region Set Round Data

    private void SetEnemy(IWeapon weapon)
    {
        view.EnemyName = weapon.Name;
        view.EnemyType = gameConfig.GetTextType(weapon.Type);
        
        view.EnemySprite = gameConfig.GetEnemySprite(weapon.Type);
        // ** TODO Change Set Enemy to:         **
        // ** view.EnemySprite = weapon.Image;  **
        // ** When sprites are ready            **
    }

    private void SetFirst(IWeapon weapon)
    {
        view.FirstChoiceName = weapon.Name;
        view.FirstChoiceType = gameConfig.GetTextType(weapon.Type);
        
        view.FirstChoiceSprite = gameConfig.GetAlliesSprite(weapon.Type);
    }

    private void SetSecond(IWeapon weapon)
    {
        view.SecondChoiceName = weapon.Name;
        view.SecondChoiceType = gameConfig.GetTextType(weapon.Type);
        
        view.SecondChoiceSprite = gameConfig.GetAlliesSprite(weapon.Type);
    }

    #endregion

    // --- Listeners ---
    private void SetListeners(bool isSet)
    {
        if (isSet)
        {
            cardLoadedSignal.AddListener(SetPhase);
            wonSignal.AddListener(ShowWinningScreen);
            lostSignal.AddListener(ShowLosingScreen);
            correctAnsweredSignal.AddListener(ShowAnimationCorrect);
            
            view.exitClickedSignal.AddListener(ShowExitConfirmPopup);
            view.firstChoiceClickedSignal.AddListener(FirstAnswerClicked);
            view.secondChoiceClickedSignal.AddListener(SecondAnswerClicked);
        }
        else
        {
            cardLoadedSignal.RemoveListener(SetPhase);
            wonSignal.RemoveListener(ShowWinningScreen);
            lostSignal.RemoveListener(ShowLosingScreen);
            correctAnsweredSignal.RemoveListener(ShowAnimationCorrect);
            
            view.exitClickedSignal.RemoveListener(ShowExitConfirmPopup);
            view.firstChoiceClickedSignal.RemoveListener(FirstAnswerClicked);
            view.secondChoiceClickedSignal.RemoveListener(SecondAnswerClicked);
        }
    }
    
    public override void OnRemove() => SetListeners(false);
}
