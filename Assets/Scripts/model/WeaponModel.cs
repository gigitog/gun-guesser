using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class WeaponModel : IWeapon
{
    [SerializeField] private string name;
    [SerializeField] private string modification;
    [SerializeField] private string year;
    [SerializeField] private string country;

    [FormerlySerializedAs("weaponClass")]
    [Tooltip("Earth, Air, Rocket, Hand Weapon")]
    [SerializeField] private WeaponClassification weaponClass;

    [Tooltip("MTB, Jet, AAW")]
    [SerializeField] private WeaponTyping type;

    [Tooltip("0 - ally; 1 - enemy")]
    [SerializeField] private int side;
    // stage ≈ lvl
    [SerializeField] private int stage;
    [SerializeField] private Sprite image;
    public int Stage => stage;
    public int Side => side;
    public WeaponTyping Type => type;
    public WeaponClassification WeaponClass => weaponClass;
    public string Country => country;
    public string Year => year;
    public string Modification => modification;
    public string Name => name;
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