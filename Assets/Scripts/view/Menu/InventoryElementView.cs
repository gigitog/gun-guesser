using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// View of Weapon Card in Inventory, when user clicks on small card.
/// </summary>
public class InventoryElementView : View
{
    [SerializeField] private TMP_Text nameField;
    [SerializeField] private TMP_Text typeField;
    [SerializeField] private TMP_Text mobilityField;
    [SerializeField] private TMP_Text stageField;
    [SerializeField] private TMP_Text sideField;
    [SerializeField] private TMP_Text countryField;
    [SerializeField] private Button elementButton;

    public Signal elementClickedSignal = new Signal();

    protected override void Awake()
    {
        base.Awake();
        SetEmptyView();
    }

    private void SetEmptyView()
    {
        nameField.text = typeField.text = mobilityField.text = stageField.text = sideField.text = countryField.text = "";
    }

    public void SetView(IWeapon weaponModel, IGameConfig gameConfig)
    {
        Name = weaponModel.Name;
        Mobility = gameConfig.GetTextMobility(weaponModel.WeaponMobility);
        Type = gameConfig.GetTextType(weaponModel.Type);
        Side = gameConfig.GetTextSide(weaponModel.Side);
        Stage = gameConfig.GetTextStage(weaponModel.Stage); // TODO config.GetInventoryElementStage(data.weapon.Stage);
    }

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
    private string Mobility
    {
        get => mobilityField.text;
        set => mobilityField.text = string.IsNullOrEmpty(value) ? "Error Mobility" : value;
    }
    private string Side
    {
        get => sideField.text;
        set => sideField.text = string.IsNullOrEmpty(value) ? "Error Side" : value;
    }
    private string Stage
    {
        get => stageField.text;
        set => stageField.text = string.IsNullOrEmpty(value) ? "Error Stage" : value;
    }
    
    private void OnEnable()
    {
        elementButton.onClick.AddListener(ElementClick);
    }

    private void OnDisable()
    {
        // Debug.LogWarning("View Disable");
        elementButton.onClick.RemoveListener(ElementClick);
    }

    private void ElementClick()
    {
        // Debug.LogWarning("MenuCardView: CardClicked");
        elementClickedSignal.Dispatch();
    }

    
}