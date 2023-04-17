/// <summary>
/// <see cref="IInventory"/> contains elements. Elements contains <see cref="IWeapon"/>
/// </summary>
public class IInventoryElement
{
    [Inject]
    public IWeapon weapon { get; set; } 
}
