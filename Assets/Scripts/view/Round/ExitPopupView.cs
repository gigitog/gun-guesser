
using System;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;
using Console = UnityEngine.Console;

public class ExitPopupView : View
{
    [SerializeField] private Button exitConfirm;
    [SerializeField] private Button exitCancel;

    public Signal<bool> exitConfirmed = new Signal<bool>();

    public void SetActive(bool isActive)
    {
        exitConfirm.interactable = exitCancel.interactable = isActive;
    }
    
    private void OnEnable() => SetListeners(true);

    private void OnDisable() => SetListeners(true);
    
    private void SetListeners(bool isSet)
    {
        if (isSet)
        {
            exitConfirm.onClick.AddListener(ExitConfirmClicked);
            exitCancel.onClick.AddListener(ExitCancelClicked);
        }
        else
        {
            exitConfirm.onClick.RemoveListener(ExitConfirmClicked);
            exitCancel.onClick.RemoveListener(ExitCancelClicked);
        }
    }

    private void ExitCancelClicked()
    {
        exitConfirmed.Dispatch(false);
    }

    private void ExitConfirmClicked()
    {
        exitConfirmed.Dispatch(true);
    }
}
