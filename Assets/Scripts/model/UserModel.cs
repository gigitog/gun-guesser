using System.Runtime.InteropServices;
using UnityEngine;

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

    [PostConstruct]
    public void PostConstruct()
    {
        Debug.Log("user Post Construct");
        Name = "Test Player Name";
        if (gameConfig != null) inventory = gameConfig.GetInitialInventory();
    }
}