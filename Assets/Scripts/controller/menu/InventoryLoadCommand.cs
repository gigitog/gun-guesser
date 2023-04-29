using System.Collections.Generic;
using strange.extensions.command.impl;
using strange.extensions.mediation.impl;
using UnityEngine;
/// <summary>
/// Process opening of the Inventory
/// </summary>
public class InventoryLoadCommand : Command
{
    [Inject] 
    public IGameConfig gameConfig {get; set;}
    
    [Inject]
    public IUser user { get; set; }

    [Inject]
    public InventoryLoadedSignal inventoryLoadedSignal { get; set; }
    public override void Execute()
    {
        // Execution
        Console.Log("ILCmd", "Execution");
        
        inventoryLoadedSignal.Dispatch(CreateInventoryElementObjects(user.inventory.inventoryList));
    }

    private List<GameObject> CreateInventoryElementObjects(List<IInventoryElement> inventoryElements)
    {
        var gameObjects = new List<GameObject>();
        foreach (var inventoryElement in inventoryElements)
        {
            var newInventoryElementObject = GameObject.Instantiate(gameConfig.InventoryElementPrefab);
            newInventoryElementObject.name = inventoryElement.weapon.Name + inventoryElement.weapon.id.Substring(0,4);
            gameObjects.Add(newInventoryElementObject);

            var inventoryElementMediator = newInventoryElementObject.GetComponent<InventoryElementMediator>();
            if (inventoryElementMediator == null)
                Console.LogError("ILCmd", "Can't get Mediator");
            // inventoryElementMediator.SetElementData(inventoryElement);
        }

        return gameObjects;
    }
}