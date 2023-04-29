using System.Collections.Generic;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Interface of Inventory<br/>
/// Is divided into categories by mobility and inside by types <br/>
/// Includes: Inventory elements, Exit <br/>
/// Stores Mono behavior objects from Unity scene
/// </summary>
public class InventoryView : View
{
    [SerializeField] private GameObject categoryPrefab;
    [SerializeField] private GameObject inventoryElementPrefab;

    [SerializeField] private RectTransform listContentParent;
    
    [SerializeField] private Button exitButton;
    [SerializeField] private Button infoButton;

    #region Dispatched Signals of User Actions

    public Signal InventoryExitClicked = new Signal();
    public Signal<GameObject> InventoryElementClicked = new Signal<GameObject>();
    public Signal InventoryInfoClicked = new Signal();

    #endregion

    public void SetInventory(List<IInventoryElement> inventoryElements)
    {
        
    }

    private void FeedPortWithElements(List<GameObject> elements)
    {
        
    }
    
    private void OnEnable()
    {
        // Add listeners
    }

    private void OnDisable()
    {
        // Remove listeners
    }
}
