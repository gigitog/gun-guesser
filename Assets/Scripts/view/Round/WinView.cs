using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Interface of Won Round
/// </summary>
public class WinView : View
{
    #region Serialize Fields
    
    [Header("Fields")]
    [SerializeField] private TMP_Text winField;
    [Header("Buttons")]
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button nextRoundButton;

    #endregion

    public Signal mainMenuCLickedSignal = new Signal();
    public Signal nextRoundClickedSignal = new Signal();
   
    private void OnEnable()
    {
        SetInteractableButtons(true);
        SetListeners(true);
    }

    private void OnDisable() => SetListeners(false);
    private void SetListeners(bool isSet)
    {
        if (isSet)
        {
            mainMenuButton.onClick.AddListener(MainMenuButtonClicked);
            nextRoundButton.onClick.AddListener(NextRoundButtonClicked);
        }
        else
        {
            mainMenuButton.onClick.RemoveListener(MainMenuButtonClicked);
            nextRoundButton.onClick.RemoveListener(NextRoundButtonClicked);
        }
    }

    private void NextRoundButtonClicked()
    {
        SetInteractableButtons(false);
        nextRoundClickedSignal.Dispatch();
    }

    private void MainMenuButtonClicked()
    {
        SetInteractableButtons(false);
        mainMenuCLickedSignal.Dispatch();
    }

    private void SetInteractableButtons(bool isInteractable) => nextRoundButton.interactable = mainMenuButton.interactable = isInteractable;
}
