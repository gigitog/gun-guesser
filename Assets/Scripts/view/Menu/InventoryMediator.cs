using System;
using strange.extensions.mediation.impl;
using UnityEngine;

public class InventoryMediator : Mediator
{
    // Add in Context:
    // mediationBinder.Bind<####View>().To<####Mediator>();
    [Inject] public InventoryView view { get; set; }

    #region Dispatched Signals

    #endregion

    #region Listen To Signals
    [Inject]
    public InventoryLoadedSignal inventoryLoadedSignal { get; set; }
    #endregion

    private void EnableView()
    {
        view.gameObject.SetActive(true);
    }

    private void DisableView()
    {
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

