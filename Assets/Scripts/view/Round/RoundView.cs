using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary>
/// Interface of Round <br/>
/// Includes: Enemy, Choices, Exit, progress, timer. <br/>
/// Stores Mono behavior objects from Unity scene
/// </summary>
public class RoundView : View
{
    #region Serialize Fields
    
    // Enemy Card
    [Header("Enemy Card")]
    [SerializeField] private TMP_Text enemyNameField;
    [SerializeField] private Image enemyMobilityType;
    [SerializeField] private Image enemyCountry;
    [SerializeField] private Image enemySprite;

    // Choices
    [Header("Choice 1")]
    [SerializeField] private TMP_Text firstChoiceNameField;
    [SerializeField] private Image firstChoiceMobility;
    [SerializeField] private Image firstChoiceSprite;
    [SerializeField] private Image firstChoiceCountry;
    [SerializeField] private Button firstChoiceButton;
    [Header("Choice 2")]
    [SerializeField] private TMP_Text secondChoiceNameField;
    [SerializeField] private Image secondChoiceMobility;
    [SerializeField] private Image secondChoiceSprite;
    [SerializeField] private Image secondChoiceCountry;
    [SerializeField] private Button secondChoiceButton;
    
    // UI
    [Header("User Interface")]
    [SerializeField] private GameObject exitPopup;
    [SerializeField] private Button exitButton; // leave round
    [SerializeField] private Slider progressBar; // track progress via bar
    [SerializeField] private TMP_Text phaseProgressCounter; // [curr/max]
    
    public Signal<int> choiceClickedSignal = new Signal<int>();
    public Signal<GameObject> exitClickedSignal = new Signal<GameObject>();
    
    #endregion
    
    #region Properties
    
    #region Enemy Properties

    public string EnemyName
    {
        get => enemyNameField.text;
        set => enemyNameField.text = string.IsNullOrEmpty(value) ? "Error Name" : value;
    }
    public Sprite EnemyMobility
    {
        get => enemyMobilityType.sprite;
        set => enemyMobilityType.sprite = value;
    }

    public Sprite EnemySprite
    {
        get => enemySprite.sprite;
        set => enemySprite.sprite = value;
    }
    
    public Sprite EnemyCountry
    {
        get => enemyCountry.sprite;
        set => enemyCountry.sprite = value;
    }

    #endregion
    
    #region Choices Properties

    public string FirstChoiceName
    {
        get => firstChoiceNameField.text;
        set => firstChoiceNameField.text = string.IsNullOrEmpty(value) ? "Error Side" : value;
    }

    public Sprite FirstChoiceMobility
    {
        get => firstChoiceMobility.sprite;
        set => firstChoiceMobility.sprite = value;
    }

    public Sprite FirstChoiceSprite
    {
        get => firstChoiceSprite.sprite;
        set => firstChoiceSprite.sprite = value;
    }
    
    public Sprite FirstChoiceCountry
    {
        get => firstChoiceCountry.sprite;
        set => firstChoiceCountry.sprite = value;
    }

    public string SecondChoiceName
    {
        get => secondChoiceNameField.text;
        set => secondChoiceNameField.text = string.IsNullOrEmpty(value) ? "Error Side" : value;
    }

    public Sprite SecondChoiceMobility
    {
        get => secondChoiceMobility.sprite;
        set => secondChoiceMobility.sprite = value;
    }

    public Sprite SecondChoiceSprite
    {
        get => secondChoiceSprite.sprite;
        set => secondChoiceSprite.sprite = value;
    }
    
    public Sprite SecondChoiceCountry
    {
        get => secondChoiceCountry.sprite;
        set => secondChoiceCountry.sprite = value;
    }
    #endregion
    
    #endregion
    
    private void OnEnable() => SetListeners(true);

    private void OnDisable() => SetListeners(false);

    /// <summary>
    /// Sets phase statistic as <see cref="phaseProgressCounter"/>
    /// </summary>
    /// <param name="indexOfEnemy"> 1..N</param>
    /// <param name="phasesQuantity"> N</param>
    public void SetPhaseStats(RoundStatsData stats)
    {
        phaseProgressCounter.text = $"{stats.currentPhaseIndex}/{stats.phasesQuantity}";
    }

    public void SetRoundInterface()
    {
        Console.Log("RoundView","meow");
        phaseProgressCounter.text = "0/N";
        gameObject.SetActive(true);
    }

    public void SetActive(bool isActive)
    {
        // Debug.Log($"[RoundView] buttons set to {isActive}");
        firstChoiceButton.interactable = secondChoiceButton.interactable = exitButton.interactable = isActive;
    }

    private void FirstChoiceClicked()
    {
        // Debug.Log("[RoundView]: [1] choice Clicked");
        choiceClickedSignal.Dispatch(1);
    }
    
    private void SecondChoiceClicked()
    {
        // Debug.Log("[RoundView]: [2] choice Clicked");
        choiceClickedSignal.Dispatch(2);
    }

    private void ExitClicked()
    {
        Console.LogWarning("RoundView","EXIT clicked");
        exitClickedSignal.Dispatch(exitPopup);
    }

    private void SetListeners(bool isSet)
    {
        if (isSet)
        {
            firstChoiceButton.onClick.AddListener(FirstChoiceClicked);
            secondChoiceButton.onClick.AddListener(SecondChoiceClicked);
            exitButton.onClick.AddListener(ExitClicked);
        }
        else
        {
            firstChoiceButton.onClick.RemoveListener(FirstChoiceClicked);
            secondChoiceButton.onClick.RemoveListener(SecondChoiceClicked);
            exitButton.onClick.RemoveListener(ExitClicked);
        }
    }
}
