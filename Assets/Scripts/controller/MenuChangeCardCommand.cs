using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

/// <summary>
/// Command gets a random <see cref="IWeapon"/> and sets it to a card in Main Menu;
/// <seealso cref="MenuCardView" /> <seealso cref="MenuCardMediator"/>
/// </summary>
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
        if (randomWeapon == null)
            Console.LogError("MCCCmd","sending null weapon!");
        
        menuMenuCardClickedSignal.Dispatch(randomWeapon);
    }

    private IWeapon GetRandomWeapon(IInventory inventory)
    {
        int id = Random.Range(0, inventory.inventoryList.Count);
        List<IInventoryElement> list = inventory.inventoryList;
        return list[id].weapon;
    }
}
