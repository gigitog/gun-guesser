
using JetBrains.Annotations;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Interface of a card in Main Menu (<see cref="MenuView"/>)
/// </summary>
public class MenuCardView : View
{
    /// <summary>
    /// Includes objects of Menu Card <br/>
    /// Stores Mono behavior objects from Unity scene
    /// </summary>
    [SerializeField] private TMP_Text nameField;
    [SerializeField] private TMP_Text typeField;
    [SerializeField] private TMP_Text classificationField;
    [SerializeField] private TMP_Text sideField;
    [SerializeField] private Button cardClickButton;
    public Signal CardClickedSignal = new Signal();

    private string Name
    {
        get => nameField.text;
        set => nameField.text = string.IsNullOrEmpty(value) ? "Error Name" : value;
    }

    private string Type
    {
        get => typeField.text;
        set => typeField.text = string.IsNullOrEmpty(value) ? "Error Type" : value;
    }
    private string Classification
    {
        get => classificationField.text;
        set => classificationField.text = string.IsNullOrEmpty(value) ? "Error Classification" : value;
    }

    private string Side
    {
        get => sideField.text;
        set => sideField.text = string.IsNullOrEmpty(value) ? "Error Side" : value;
    }

    public void SetCard(IWeapon weapon, IGameConfig gameConfig)
    {
        Name = weapon.Name;
        Classification = gameConfig.GetTextMobility(weapon.WeaponMobility);
        Type = gameConfig.GetTextTypeLong(weapon.Type);
        Side = weapon.Side.ToString();
    }
    
    private void OnEnable()
    {
        cardClickButton.onClick.AddListener(CardClick);
    }

    private void OnDisable()
    {
        // Debug.LogWarning("View Disable");
        cardClickButton.onClick.RemoveListener(CardClick);
    }

    private void CardClick()
    {
        // Debug.LogWarning("MenuCardView: CardClicked");
        CardClickedSignal.Dispatch();
    }
}
