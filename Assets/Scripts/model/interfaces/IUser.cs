/// <summary>
/// User interface gives access to user data: <br/>
/// - name <br/>
/// - exp, lvl <br/>
/// - hearts <br/>
/// - <see cref="IInventory"/> <br/>
/// - ??? <br/>
/// </summary>
public interface IUser
{
    public string Name { get; set; }
    public long Experience { get; set; }
    public long Level { get;  }
    public byte Hearts { get; set; }
    public IInventory inventory {get; set;}
}