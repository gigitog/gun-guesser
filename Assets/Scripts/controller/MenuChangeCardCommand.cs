
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class MenuChangeCardCommand : Command
{
    [Inject]
    public IUser user { get; set; }
    [Inject]
    public MenuCardChangedSignal menuMenuCardClickedSignal { get; set; }

    public override void Execute()
    {
        // Debug.Log("MenuChangeCardCommand Execution...");
        IWeapon randomWeapon = GetRandomWeapon(user.inventory);
        menuMenuCardClickedSignal.Dispatch(randomWeapon);
    }

    private IWeapon GetRandomWeapon(IInventory inventory)
    {
        int id = Random.Range(0, inventory.inventoryList.Count);
        List<IInventoryElement> list = inventory.inventoryList;
        return list[id].weapon;
    }
}
