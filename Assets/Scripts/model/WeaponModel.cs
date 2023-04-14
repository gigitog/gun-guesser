using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class WeaponModel : IWeapon
{
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private string year;
    [SerializeField] private string country;
    
    [Tooltip("Earth, Air, Rocket, Hand Weapon")]
    [NotEditable] [SerializeField] private WeaponMobility weaponMobility;

    [Tooltip("MTB, Jet, AAW")]
    [NotEditable] [SerializeField] private WeaponTyping type;

    [Tooltip("0 - ally; 1 - enemy")]
    [NotEditable] [SerializeField] private WeaponSide side;
    // stage ≈ lvl
    [SerializeField] private int stage;
    [SerializeField] private Sprite image;
    public int Stage => stage;
    public WeaponSide Side
    {
        get => side;
        set => side = value;
    }

    public WeaponTyping Type
    {
        get => type;
        set => type = value;
    }

    public WeaponMobility WeaponMobility
    {
        get => weaponMobility;
        set
        {
            weaponMobility = value;
            SetMobility();
        }
    }

    public string Country
    {
        get => country;
        set => country = value;
    }

    public string Year
    {
        get => year;
        set => year = value;
    }

    public string Description
    {
        get => description;
        set => description = value;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public Sprite Image => image;

    public WeaponModel(WeaponSide side, WeaponTyping type)
    {
        this.side = side;
        this.type = type;
        SetMobility();
    }

    public WeaponModel() { }

    private void SetMobility()
    {
        weaponMobility = type switch
        {
            WeaponTyping.MBT => WeaponMobility.Ground,
            WeaponTyping.MLRS => WeaponMobility.Ground,
            WeaponTyping.APC => WeaponMobility.Ground,
            WeaponTyping.IFV => WeaponMobility.Ground,
            WeaponTyping.SPH => WeaponMobility.Ground,
            WeaponTyping.Towed => WeaponMobility.Ground,
            WeaponTyping.AAW => WeaponMobility.Ground,
            WeaponTyping.UAV => WeaponMobility.Air,
            WeaponTyping.Fighter => WeaponMobility.Air,
            WeaponTyping.Bomber => WeaponMobility.Air,
            WeaponTyping.AH => WeaponMobility.Air,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}

public enum WeaponMobility
{
    Ground,
    Air,
    Missile,
    Hand
}

public enum WeaponTyping
{
    MBT = 0,
    MLRS = 1,
    APC = 2,
    IFV = 3,
    SPH = 4,
    Towed = 5,
    AAW = 6,
    UAV = 7,
    Fighter = 8,
    Bomber = 9,
    AH = 10
}

public enum WeaponSide
{
    Ally = 0,
    Enemy = 1
}