
using UnityEngine;

public interface IWeapon
{
    public int Stage { get; }
    public WeaponSide Side { get; set; }
    public WeaponTyping Type { get; }
    public WeaponClassification WeaponClass { get; }
    public string Country { get; }
    public string Year { get; }
    public string Description { get; }
    public string Name { get; }
    public Sprite Image { get; }
}
