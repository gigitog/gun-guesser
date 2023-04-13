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
    [SerializeField] private WeaponClassification weaponClass;

    [Tooltip("MTB, Jet, AAW")]
    [SerializeField] private WeaponTyping type;

    [Tooltip("0 - ally; 1 - enemy")]
    [SerializeField] private WeaponSide side;
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

    public WeaponClassification WeaponClass
    {
        get => weaponClass;
        set => weaponClass = value;
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
}

public enum WeaponClassification
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
    UAV = 4,
    SPH = 5,
    Towed = 6,
    Fighter = 7,
    Bomber = 8,
    AH = 9,
    AAW = 10
}

public enum WeaponSide
{
    Ally = 0,
    Enemy = 1
}