using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponConfig", order = 1)]
public class WeaponConfigScriptableObject : ScriptableObject
{
    public List<WeaponConfigModel> weapons;
    
    [Header("Weapon Classification")] 
    [SerializeField] private List<ClassificationToString> mobilityTypes;
    
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
                return mobilityType.classificationText;
            }
        }

        return errorText;
    }
}

[Serializable]
public class WeaponConfigModel
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

[Serializable]
public class ClassificationToString
{
    public string classificationText;
    public WeaponMobility mobility;
}

