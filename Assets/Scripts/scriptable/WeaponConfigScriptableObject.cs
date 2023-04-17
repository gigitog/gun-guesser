using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Weapon Configuration serves for Game Design purpose to get general information
/// about the types <see cref="WeaponTyping"/> of weapons, their Counter Weapons Values.
/// <para></para>
/// Here are stored configurations of weapons "<see cref="WeaponTypeConfigModel"/>".
/// Also here are stored information about <see cref="WeaponMobility"/> to it string value. "<see cref="MobilityTypeToString"/>".
/// <remarks>Game Design</remarks>
/// </summary>
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponConfig", order = 1)]
public class WeaponConfigScriptableObject : ScriptableObject, IWeaponConfig
{
    [Header("Weapon Models")] 
    public List<WeaponTypeConfigModel> weapons;
    
    [Header("Weapon Mobility types")] 
    [SerializeField] private List<MobilityTypeToString> mobilityTypes;
    
    [Header("Errors")] 
    [SerializeField] private string errorText;

    public string GetShortType(WeaponTyping searchedTyping)
    {
        foreach (var model in weapons)
        {
            if (model.typing == searchedTyping)
            {
                return model.abbreviation;
            }
        }

        return errorText;
    }
    public string GetFullType(WeaponTyping searchedTyping)
    {
        foreach (var model in weapons)
        {
            if (model.typing == searchedTyping)
            {
                return model.name;
            }
        }

        return errorText;
    }

    public string GetMobilityType(WeaponMobility searchedMobility)
    {
        foreach (var mobilityType in mobilityTypes)
        {
            if (mobilityType.mobility == searchedMobility)
            {
                return mobilityType.mobilityText;
            }
        }

        return errorText;
    }
}

/// <summary>
/// Weapon Type Config Model is represented in Unity Editor in <see cref="WeaponConfigScriptableObject"/>.
/// <para></para>
/// It fully depends on <see cref="WeaponTyping"/>. And all of its attributes are determined by this Typing.
/// <example> Model:<code>
///     abbreviation = MBT;<br/>
///     name = Main Battle Tank;<br/>
///     default sprite = ###;<br/>
///     typing = WeaponTyping.MBT; <br/>
///     mobility = WeaponMobility.Ground<br/>
///     Counter Weapons =  7, 1, 5, 8 ...;<br/>
/// </code></example>
/// <remarks>Game Design</remarks>
/// </summary>
[Serializable]
public class WeaponTypeConfigModel
{
    public string abbreviation;
    public string name;
    public Sprite defaultSprite;
    [Space(10)]
    public WeaponTyping typing;
    public WeaponMobility mobility;
    
    [Header("Counter Weapon")]
    [Tooltip("MBT = 0 \n" +
             "LRS = 1 \n" +
             "APC = 2 \n" +
             "IFV = 3 \n" +
             "UAV = 4 \n" +
             "SPH = 5 \n" +
             "tow = 6 \n" +
             "jet = 7 \n" +
             "bbr = 8 \n" +
             "AHe = 9 \n" +
             "AAW = 10")]
    public int mbt;
    public int mlrs;
    public int apc;
    public int ifv;
    public int uav;
    public int sph;
    public int towed;
    public int fighter;
    [FormerlySerializedAs("bombers")] public int bomber;
    public int ah;
    public int aaw;

    public int GetValue(WeaponTyping typing)
    {
        return typing switch
        {
            WeaponTyping.MBT => mbt,
            WeaponTyping.MLRS => mlrs,
            WeaponTyping.APC => apc,
            WeaponTyping.IFV => ifv,
            WeaponTyping.UAV => uav,
            WeaponTyping.SPH => sph,
            WeaponTyping.Towed => towed,
            WeaponTyping.Fighter => fighter,
            WeaponTyping.Bomber => bomber,
            WeaponTyping.AH => ah,
            WeaponTyping.AAW => aaw,
            _ => throw new ArgumentOutOfRangeException(nameof(typing), typing, null)
        };
    }
}
/// <summary>
/// Class to translate <see cref="WeaponMobility"/> to text format
/// <remarks>Game Design</remarks>
/// </summary>
[Serializable]
public class MobilityTypeToString
{
    public string mobilityText;
    public WeaponMobility mobility;
}

