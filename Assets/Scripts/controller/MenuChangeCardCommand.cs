
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class MenuChangeCardCommand : Command
{
    [Inject]
    public IUser user { get; set; }
    [Inject]
    public MenuCardChangedSignal menuCardChangedSignal { get; set; }

    public override void Execute()
    {
        IWeapon randomWeapon = GetRandomWeapon(user.inventory);
        menuCardChangedSignal.Dispatch(randomWeapon);
    }

    private IWeapon GetRandomWeapon(IInventory inventory)
    {
        int id = Random.Range(0, inventory.GetInventoryList().Count);
        List<IInventoryElement> list = inventory.GetInventoryList();
        return list[id].weapon;
    }
}
