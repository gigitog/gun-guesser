
public class InventoryElementModel : IInventoryElement
{
    [Inject]
    public IWeapon weapon { get; set; }
}
