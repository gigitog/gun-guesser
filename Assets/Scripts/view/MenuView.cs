using System;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : View
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button userProfileButton;
    [SerializeField] private Button inventoryButton;

    public Signal MenuInventoryClickedSignal = new Signal();
    public Signal MenuProfileClickedSignal = new Signal();
    public Signal MenuStartClickedSignal = new Signal();

    private void OnEnable()
    {
        startButton.onClick.AddListener(StartClick);
        userProfileButton.onClick.AddListener(ProfileClick);
        inventoryButton.onClick.AddListener(InventoryClick);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(StartClick);
        userProfileButton.onClick.RemoveListener(ProfileClick);
        inventoryButton.onClick.RemoveListener(InventoryClick);
    }
    
    public void StartClick()
    {
        MenuStartClickedSignal.Dispatch();
    }

    public void ProfileClick()
    {
        MenuProfileClickedSignal.Dispatch();
    }

    public void InventoryClick()
    {
        MenuInventoryClickedSignal.Dispatch();
    }

    
    public void StartClicked()
    {
        MenuStartClickedSignal.Dispatch();
    }
}
