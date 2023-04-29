using UnityEngine;

/// <summary>
/// User Model derives from <see cref="IUser"/> <br/>
/// </summary>
public class UserModel : IUser
{
    public string Id { get; private set; }
    public string Name { get; set; }
    public long Experience { get; set; }
    public long Level { get; private set;  }
    public byte Hearts { get; set; }
    
    // --- interface ---
    
    [Inject]
    public IInventory inventory { get; set; }
    
    [Inject]
    public IGameConfig gameConfig { get; set; }
    
    [Inject]
    public IGameRules gameRules { get; set; }

    [PostConstruct]
    public void PostConstruct()
    {
        // Debug.Log("[UserModel] Post Construct");
        Console.Log("UserModel", "PostConstruct");
        Name = "Test Player Name";
        if (gameConfig != null) inventory = gameRules.GetInitialInventory();
        Console.Log("UserModel", $"user inv capacity = {inventory.inventoryList.Count}");
    }
}