
using UnityEngine;

public interface IWeapon
{
    public int Stage { get; }
    public int Side { get; }
    public WeaponTyping Type { get; }
    public WeaponClassification WeaponClass { get; }
    public string Country { get; }
    public string Year { get; }
    public string Modification { get; }
    public string Name { get; }
    public Sprite Image { get; }
}
