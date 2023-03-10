public class UserModel : IUser
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public long Experience { get; private set; }
    public long Level { get; private set;  }
    public byte Hearts { get; set; }
    
    // --- interface ---
    public IInventory inventory { get; set; }
}

public interface IUser
{
    public IInventory inventory {get; set;}
}