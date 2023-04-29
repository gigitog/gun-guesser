using System;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

/// <summary>
/// bounds relationship between <see cref="InventoryView"/> and rest of the App
/// </summary>
public class InventoryMediator : Mediator
{
    [Inject] public InventoryView view { get; set; }

    #region Dispatched Signals (BackToMenu)
    
    [Inject]
    public InventoryToMenuSignal inventoryToMenuSignal { get; set; }
    
    #endregion

    #region Listen To Signals
    
    [Inject]
    public InventoryLoadedSignal inventoryLoadedSignal { get; set; }
    
    #endregion

    private void EnableView(List<GameObject> obj)
    {
        view.SetInventory(obj);
        view.SetActive(true);
    }

    private void DisableView()
    {
        view.SetActive(false);
        throw new NotImplementedException();
    }

    public override void OnRegister()
    {
        SetListeners(true);
    }

    public override void OnRemove()
    {
        SetListeners(false);
    }

    private void OnInfoClicked()
    {
        // TODO implement info window in inventory
        throw new NotImplementedException();
    }

    private void OnExitClicked()
    {
        // TODO Implement exit from Inventory
        throw new NotImplementedException();
    }

    private void OnElementClicked(GameObject obj)
    {
        // TODO Get Info what InventoryElement was clicked
        throw new NotImplementedException();
    }

    private void SetListeners(bool isSet)
    {
        if (isSet)
        {
            inventoryLoadedSignal.AddListener(EnableView);
            // Add Listeners
            view.InventoryElementClicked.AddListener(OnElementClicked);
            view.InventoryExitClicked.AddListener(OnExitClicked);
            view.InventoryInfoClicked.AddListener(OnInfoClicked);
        }
        else
        {
            inventoryLoadedSignal.RemoveListener(EnableView);
            // Remove Listeners
            view.InventoryElementClicked.RemoveListener(OnElementClicked);
            view.InventoryExitClicked.RemoveListener(OnExitClicked);
            view.InventoryInfoClicked.RemoveListener(OnInfoClicked);
        }
    }
}

