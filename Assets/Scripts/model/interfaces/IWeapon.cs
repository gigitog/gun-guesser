
using UnityEngine;

/// <summary>
/// It describes the weapon object in game, which could be represented as: <br/>
///     - Enemy card in Round <br/>
///     - Choice in Round <br/>
///     - Card in Main Menu <br/>
///     - In inventory as a part of <see cref="IInventoryElement"/>
/// </summary>
public interface IWeapon
{
    public int Stage { get; }
    public WeaponSide Side { get; set; }
    public WeaponTyping Type { get; }
    public WeaponMobility WeaponMobility { get; }
    public string Country { get; }
    public string Year { get; }
    public string Description { get; }
    public string Name { get; }
    public Sprite Image { get; }
}
