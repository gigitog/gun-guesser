using System;
using strange.extensions.mediation.impl;
using Console = UnityEngine.Console;

/// <summary>
/// bounds relationship between <see cref="InventoryElementView"/> and rest of the App
/// </summary>
public class InventoryElementMediator : Mediator
{
    // Mediator knows, what weapon is here
    [Inject] public InventoryElementView view { get; set; }

    [Inject]
    public IGameConfig gameConfig { get; set; }

    public IInventoryElement element { get; set; }

    #region Dispatched Signals (invElemClicked)
    
    [Inject]
    public InventoryElementClickedSignal inventoryElementClickedSignal { get; set; }
    
    #endregion

    #region Listen To Signals

    #endregion

    public void SetElementData(IInventoryElement data)
    {
        element = data;

        view.SetView(element.weapon, gameConfig);
    }

    private void EnableView()
    {
        throw new NotImplementedException();
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

    private void SetListeners(bool isSet)
    {
        if (isSet)
        {
            // Add Listeners
        }
        else
        {
            // Remove Listeners
        }
    }
}

