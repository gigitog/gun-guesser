
using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;

public class MenuCardView : View
{
    [SerializeField] private TMP_Text nameField;
    [SerializeField] private TMP_Text typeField;
    [SerializeField] private TMP_Text classificationField;
    [SerializeField] private TMP_Text sideField;

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
    public string Classification
    {
        get => classificationField.text;
        set => classificationField.text = string.IsNullOrEmpty(value) ? "Error Classification" : value;
    }
    public string Side
    {
        get => sideField.text;
        set => sideField.text = string.IsNullOrEmpty(value) ? "Error Side" : value;
    }
}
