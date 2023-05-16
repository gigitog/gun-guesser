
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
    [SerializeField] private TMP_Text descriptionField;
    [SerializeField] private Image mobilityType;
    [SerializeField] private Image country;
    [SerializeField] private Image weaponImage;
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
    private string Description
    {
        get => descriptionField.text;
        set => descriptionField.text = string.IsNullOrEmpty(value) ? "Error Type" : value;
    }
    
    private Sprite MobilityType
    {
        get => mobilityType.sprite;
        set => mobilityType.sprite = value;
    }

    private Sprite Country
    {
        get => country.sprite;
        set => country.sprite = value;
    }

    private Sprite WeaponImage
    {
        get => weaponImage.sprite;
        set => weaponImage.sprite = value;
    }

    public void SetCard(IWeapon weapon, IGameConfig gameConfig)
    {
        Name = weapon.Name;
        Description = weapon.Description;
        
        WeaponImage = weapon.Side == WeaponSide.Ally 
            ? gameConfig.GetAlliesSprite(weapon.Type) 
            : gameConfig.GetEnemySprite(weapon.Type);
        
        MobilityType = gameConfig.GetImageMobility(weapon.WeaponMobility);
        Country = gameConfig.GetImageCountry(weapon.Country);
        Type = gameConfig.GetTextType(weapon.Type);
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
