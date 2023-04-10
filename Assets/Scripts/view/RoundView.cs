
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class RoundView : View
{
    #region Serialize Fields
    
    // Enemy Card
    [Header("Enemy Card")]
    [SerializeField] private TMP_Text enemyNameField;
    [SerializeField] private TMP_Text enemyTypeField;
    [SerializeField] private Image enemySprite;

    // Choices
    [Header("Choice 1")]
    [SerializeField] private TMP_Text firstChoiceNameField;
    [SerializeField] private TMP_Text firstChoiceTypeField;
    [SerializeField] private Image firstChoiceSprite;
    [SerializeField] private Button firstChoiceButton;
    [Header("Choice 2")]
    [SerializeField] private TMP_Text secondChoiceNameField;
    [SerializeField] private TMP_Text secondChoiceTypeField;
    [SerializeField] private Image secondChoiceSprite;
    [SerializeField] private Button secondChoiceButton;
    
    // UI
    [Header("User Interface")]
    [SerializeField] private Button exitButton; // leave round
    [SerializeField] private Slider progressBar; // track progress via bar
    [SerializeField] private TMP_Text phaseProgressCounter; // [curr/max]
    
    public Signal firstChoiceClickedSignal = new Signal();
    public Signal secondChoiceClickedSignal = new Signal();
    public Signal exitClickedSignal = new Signal();
    
    #endregion
    
    #region Properties

    // Enemy -------------- Properties
    public string EnemyName
    {
        get => enemyNameField.text;
        set => enemyNameField.text = string.IsNullOrEmpty(value) ? "Error Name" : value;
    }
    public string EnemyType
    {
        get => enemyTypeField.text;
        set => enemyTypeField.text = string.IsNullOrEmpty(value) ? "Error Type" : value;
    }

    public Sprite EnemySprite
    {
        get => enemySprite.sprite;
        set => enemySprite.sprite = value;
    }
    
    // Choices -------------- Properties
    
    public string FirstChoiceName
    {
        get => firstChoiceNameField.text;
        set => firstChoiceNameField.text = string.IsNullOrEmpty(value) ? "Error Side" : value;
    }

    public string FirstChoiceType
    {
        get => firstChoiceTypeField.text;
        set => firstChoiceTypeField.text = string.IsNullOrEmpty(value) ? "Error Side" : value;
    }

    public Sprite FirstChoiceSprite
    {
        get => firstChoiceSprite.sprite;
        set => firstChoiceSprite.sprite = value;
    }

    public string SecondChoiceName
    {
        get => secondChoiceNameField.text;
        set => secondChoiceNameField.text = string.IsNullOrEmpty(value) ? "Error Side" : value;
    }

    public string SecondChoiceType
    {
        get => secondChoiceTypeField.text;
        set => secondChoiceTypeField.text = string.IsNullOrEmpty(value) ? "Error Side" : value;
    }

    public Sprite SecondChoiceSprite
    {
        get => secondChoiceSprite.sprite;
        set => secondChoiceSprite.sprite = value;
    }

    #endregion
    
    private void OnEnable() => SetListeners(true);

    private void OnDisable() => SetListeners(false);

    private void FirstChoiceClicked()
    {
        Debug.LogWarning("RoundView: [1] choice Clicked");
        firstChoiceClickedSignal.Dispatch();
    }
    
    private void SecondChoiceClicked()
    {
        Debug.LogWarning("RoundView: [2] choice Clicked");
        secondChoiceClickedSignal.Dispatch();
    }

    private void ExitClicked()
    {
        Debug.LogWarning("RoundView: EXIT clicked");
        exitClickedSignal.Dispatch();
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
