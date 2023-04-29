using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Interface of Main Menu<br/>
/// Includes: Start, User and Inventory buttons <br/>
/// Stores Mono behavior objects from Unity scene
/// </summary>
public class MenuView : View
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button userProfileButton;
    [SerializeField] private Button inventoryButton;
    [SerializeField] private TMP_Text hearts;

    #region Dispatched Signals of User Actions

    public Signal MenuInventoryClickedSignal = new Signal();
    public Signal MenuProfileClickedSignal = new Signal();
    public Signal MenuStartClickedSignal = new Signal();

    #endregion
    
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

    private void StartClick()
    {
        MenuStartClickedSignal.Dispatch();
    }

    private void ProfileClick()
    {
        MenuProfileClickedSignal.Dispatch();
    }

    private void InventoryClick()
    {
        MenuInventoryClickedSignal.Dispatch();
    }

    
    public void StartClicked()
    {
        MenuStartClickedSignal.Dispatch();
    }
}
