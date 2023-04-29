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
    [SerializeField] private Button elementButton;

    public Signal elementClickedSignal = new Signal();

    public string Name
    {
        get => nameField.text;
        set => nameField.text = string.IsNullOrEmpty(value) ? "Error Name" : value;
    }
    public string Type
    {
        get => typeField.text;
        set => typeField.text = string.IsNullOrEmpty(value) ? "Error Type" : value;
    }
    public string Mobility
    {
        get => mobilityField.text;
        set => mobilityField.text = string.IsNullOrEmpty(value) ? "Error Mobility" : value;
    }
    public string Side
    {
        get => sideField.text;
        set => sideField.text = string.IsNullOrEmpty(value) ? "Error Side" : value;
    }
    public string Stage
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