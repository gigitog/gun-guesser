/// <summary>
/// Element Model derives from <see cref="IInventoryElement"/> <br/>
/// </summary>
public class InventoryElementModel : IInventoryElement
{
    [Inject]
    public IWeapon weapon { get; set; }
}
