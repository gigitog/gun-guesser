using System;
using UnityEngine;
using Util;

/// <summary>
/// Weapon Model derives from <see cref="IWeapon"/> <br/>
/// </summary>
[Serializable]
public class WeaponModel : IWeapon
{
    [SerializeField] private string name;
    [NotEditable] [SerializeField] private string identificationNumber = Guid.NewGuid().ToString();
    [SerializeField] private string description;
    [SerializeField] private string year;
    [SerializeField] private CountryNames country;
    
    [Tooltip("Earth, Air, Rocket, Hand Weapon")]
    [NotEditable] [SerializeField] private WeaponMobility weaponMobility;

    [Tooltip("MTB, Jet, AAW")]
    [NotEditable] [SerializeField] private WeaponTyping type;

    [Tooltip("0 - ally; 1 - enemy")]
    [NotEditable] [SerializeField] private WeaponSide side;
    // stage ≈ lvl
    [SerializeField] private int stage;
    [SerializeField] private Sprite image;
    
    public string id => identificationNumber;
    
    public void SetNewGUID() => identificationNumber = Guid.NewGuid().ToString();
    
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

    public CountryNames Country
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


/// <summary>
/// Weapon Mobility Typing <br/>
/// Ground, Air, Missile, Hand
/// </summary>
public enum WeaponMobility
{
    Ground,
    Air,
    Missile,
    Hand,
    Naval
}

/// <summary>
/// Weapon Typing <br/>
/// MBT, MLRS, APC, IFV, SPH, Towed, AAW, UAV, Fighter, Bomber, AH
/// </summary>
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

/// <summary>
/// Weapon Side: "Ally" -- "Enemy"
/// </summary>
public enum WeaponSide
{
    Ally = 0,
    Enemy = 1
}