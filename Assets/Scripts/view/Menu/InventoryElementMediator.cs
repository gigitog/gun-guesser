using System;
using strange.extensions.mediation.impl;

public class InventoryElementMediator : Mediator
{
    // Add in Context:
    // mediationBinder.BindView<####View>().To<####Mediator>();
    
    // Mediator knows, what weapon is here
    [Inject] public InventoryElementView view { get; set; }

    [Inject]
    public IGameConfig config { get; set; }

    public IInventoryElement element { get; set; }

    #region Dispatched Signals
    
    public InventoryElementClickedSignal inventoryElementClickedSignal { get; set; }
    
    #endregion

    #region Listen To Signals

    #endregion

    public void SetElement(IInventoryElement data)
    {
        element = data;

        FillData();
    }

    private void FillData()
    {
        view.Name = element.weapon.Name;
        view.Type = config.GetTextType(element.weapon.Type);
        view.Mobility = config.GetTextMobility(element.weapon.WeaponMobility);
        view.Side = "TODO";
        view.Stage = element.weapon.Stage.ToString(); // TODO config.GetInventoryElementStage(data.weapon.Stage);
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

