
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Interface of Lost Round
/// </summary>
public class LoseView : View
{
    #region Serialize Fields
    
    [Header("Fields")]
    [SerializeField] private TMP_Text loseField;
    [Header("Buttons")]
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button againRoundButton;

    #endregion
    
    public string LoseField { get => loseField.text; set => loseField.text = value; }
    

    public Signal mainMenuCLickedSignal = new Signal();
    public Signal againRoundClickedSignal = new Signal();
   
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
            againRoundButton.onClick.AddListener(NextRoundButtonClicked);
        }
        else
        {
            mainMenuButton.onClick.RemoveListener(MainMenuButtonClicked);
            againRoundButton.onClick.RemoveListener(NextRoundButtonClicked);
        }
    }

    private void NextRoundButtonClicked()
    {
        SetInteractableButtons(false);
        againRoundClickedSignal.Dispatch();
    }

    private void MainMenuButtonClicked()
    {
        SetInteractableButtons(false);
        mainMenuCLickedSignal.Dispatch();
    }

    private void SetInteractableButtons(bool isInteractable) => againRoundButton.interactable = mainMenuButton.interactable = isInteractable;
}
