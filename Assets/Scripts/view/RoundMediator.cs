
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

/// <summary>
/// bounds relationship between <see cref="RoundView"/> and controllers
/// </summary>
public class RoundMediator : Mediator
{
    [Inject] 
    public RoundView view { get; set; }
    
    [Inject]
    public IGameConfig gameConfig { get; set; }

    #region Signals dispatched (answer/getPhase)
        [Inject]
        public RoundGetPhaseSignal getPhaseSignal { get; set; }
        
        [Inject]
        public RoundAnsweredSignal answeredSignal { get; set; }
    #endregion

    #region Listen To Signals
        [Inject]
        public RoundLoadedSignal loadedSignal { get; set; }
        
        [Inject]
        public RoundPhaseLoadedSignal phaseLoadedSignal { get; set; }
        [Inject]
        public RoundWonSignal wonSignal { get; set; }
        [Inject]
        public RoundLostSignal lostSignal { get; set; }
        [Inject]
        public RoundCorrectSignal correctSignal { get; set; }
    #endregion

    public override void OnRegister()
    {
        SetListeners(true);
    }
    
    private void AnswerClicked(int position)
    {
        view.SetActive(false);
        answeredSignal.Dispatch(position);
    }

    private void SetPhase(IWeapon enemy, Dictionary<int, IWeapon> choicesWeapons, RoundStatsData data)
    {
        // Console.LogWarning("RoundMediator", $"Setting phase data: \n" +
        //                  $"Enemy {enemy.Name}\n" +
        //                  $"1 - {choicesWeapons[1].Name}\n" +
        //                  $"2 - {choicesWeapons[2].Name}");
        view.SetPhaseStats(data);
        SetEnemy(enemy);
        SetFirst(choicesWeapons[1]);
        SetSecond(choicesWeapons[2]);
        view.SetActive(true);
    }

    #region Show UI Screens
    
    private void ShowExitConfirmPopup()
    {
        Console.LogWarning("RoundMediator", "Show Exit");
        throw new System.NotImplementedException();
    }

    private void ShowAnimationOfCorrect()
    {
        Console.LogWarning("RoundMediator", "Show Correct Animation");
        getPhaseSignal.Dispatch();
        // throw new System.NotImplementedException();
    }

    private void ShowLosingScreen(IWeapon weapon)
    {
        Console.LogWarning("RoundMediator", "Show Lose");
        Console.LogWarning("RoundMediator", $"It was better to use {weapon.Name}");
    }

    private void ShowWinningScreen()
    {
        Console.LogWarning("RoundMediator", " Show Win");
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
    private void SetRound()
    {
        view.SetRoundInterface();
    }

    #endregion

    // --- Listeners ---
    private void SetListeners(bool isSet)
    {
        if (isSet)
        {
            loadedSignal.AddListener(SetRound);
            phaseLoadedSignal.AddListener(SetPhase);
            wonSignal.AddListener(ShowWinningScreen);
            lostSignal.AddListener(ShowLosingScreen);
            correctSignal.AddListener(ShowAnimationOfCorrect);
            
            view.exitClickedSignal.AddListener(ShowExitConfirmPopup);
            view.choiceClickedSignal.AddListener(AnswerClicked);
        }
        else
        {
            loadedSignal.RemoveListener(SetRound);
            phaseLoadedSignal.RemoveListener(SetPhase);
            wonSignal.RemoveListener(ShowWinningScreen);
            lostSignal.RemoveListener(ShowLosingScreen);
            correctSignal.RemoveListener(ShowAnimationOfCorrect);
            
            view.exitClickedSignal.RemoveListener(ShowExitConfirmPopup);
            view.choiceClickedSignal.RemoveListener(AnswerClicked);
        }
    }

    public override void OnRemove() => SetListeners(false);
}
