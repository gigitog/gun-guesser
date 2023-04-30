using System.Collections;
using System.Collections.Generic;
using strange.examples.signals;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
/// <summary>
/// Process opening of the Inventory
/// </summary>
public class InventoryLoadCommand : Command
{
    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView{get;set;}
    
    [Inject] 
    public IGameConfig gameConfig {get; set;}
    
    [Inject]
    public IUser user { get; set; }

    [Inject]
    public InventoryLoadedSignal inventoryLoadedSignal { get; set; }

    private Signal<List<GameObject>> allMediatorsLoadedSignal = new Signal<List<GameObject>>();
    
    public override void Execute()
    {
        // Execution
        Console.Log("ILCmd", "Execution");
        Retain();
        var objects = CreateInventoryElementObjects(user.inventory.inventoryList);
        
        allMediatorsLoadedSignal.AddListener(OnComplete);

        MonoBehaviour root = contextView.GetComponent<Root>();
        root.StartCoroutine(WaitForMediatorsRegistration(objects));
    }

    public void OnComplete(List<GameObject> objectsToSend)
    {
        for (int i = 0; i < objectsToSend.Count; i++)
        {
            var inventoryElementMediator = objectsToSend[i].GetComponent<InventoryElementMediator>();
            if (inventoryElementMediator == null)
            {
                Console.LogError("ILCmd", "[OnComplete] Can't get Mediator");
                return;
            }
            inventoryElementMediator.SetElementData(user.inventory.inventoryList[i]);
        }
        Console.Log("ILCmd", $"[OnComplete] Complete! All data was filled!");
        inventoryLoadedSignal.Dispatch(objectsToSend);
        Release();
    }

    private List<GameObject> CreateInventoryElementObjects(List<IInventoryElement> inventoryElements)
    {
        var gameObjects = new List<GameObject>();
        foreach (var inventoryElement in inventoryElements)
        {
            var newInventoryElementObject = GameObject.Instantiate(gameConfig.InventoryElementPrefab);
            newInventoryElementObject.name = inventoryElement.weapon.Name + inventoryElement.weapon.id.Substring(0,4);
            gameObjects.Add(newInventoryElementObject);
        }
        Console.Log("ILCmd", $"[CreateInvElemObjs] InventoryElementObjects were created; Count = {gameObjects.Count}");
        return gameObjects;
    }
    
    private IEnumerator WaitForMediatorsRegistration(List<GameObject> objects)
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            Console.LogWarning("ILCmd", $"[WaitForMediators] Checking for all mediators");
            bool areAllReady = AreAllMediatorsExisting(objects);
            if (areAllReady)
            {
                Console.LogWarning("ILCmd", $"[WaitForMediators] Mediators Are ready");
                allMediatorsLoadedSignal.Dispatch(objects);
                break;
            }
        }
    }

    private bool AreAllMediatorsExisting(List<GameObject> objects)
    {
        foreach (var gameObject in objects)
        {
            if (gameObject.GetComponent<InventoryElementMediator>() == null)
            {
                return false;
            }
        }

        return true;
    }
}