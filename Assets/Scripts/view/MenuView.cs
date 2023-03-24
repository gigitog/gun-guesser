using System;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : View
{
    [SerializeField] private Button cardClickButton;
    
    
    public Signal MenuInventoryClickedSignal { get; set; }
    public Signal MenuProfileClickedSignal { get; set; }
    public Signal StartClickedSignal { get; set; }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
    
    public void StartClick()
    {
        
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
        StartClickedSignal.Dispatch();
    }
}
