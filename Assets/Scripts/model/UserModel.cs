public class UserModel : IUser
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public long Experience { get; set; }
    public long Level { get; private set;  }
    public byte Hearts { get; set; }
    
    // --- interface ---
    
    [Inject]
    public IInventory inventory { get; set; }
}

public interface IUser
{
    public string Name { get; }
    public long Experience { get; set; }
    public long Level { get;  }
    public byte Hearts { get; set; }
    public IInventory inventory {get; set;}
}