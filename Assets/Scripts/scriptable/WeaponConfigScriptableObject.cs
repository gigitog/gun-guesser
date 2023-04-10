using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponConfig", order = 1)]
public class WeaponConfigScriptableObject : ScriptableObject
{
    public List<WeaponConfigModel> weapons;
    
    [Header("Weapon Classification")] 
    [SerializeField] private List<ClassificationToString> classifications;
    
    [Header("Errors")] 
    [SerializeField] private string errorText;

    public bool CompareWeapons(IWeapon enemy, IWeapon weapon)
    {
        List<WeaponTyping> weaponsAgainstEnemy = null;
        foreach (var model in weapons)
        {
            if (enemy.Type == model.typing)
            {
                // weaponsAgainstEnemy = model.counterWeapons[];
            }
            else
            {
                Debug.LogError("Could not find Type of this enemy in WeaponConfig!");
                return false;
            }
        }

        if (weaponsAgainstEnemy == null) return false;
        
        foreach (var weaponTyping in weaponsAgainstEnemy)
        {
            if (weapon.Type == weaponTyping)
            {
                return true;
            }
        }

        return false;
    }
    
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

    public string GetClassification(WeaponClassification searchedClassification)
    {
        foreach (var classification in classifications)
        {
            if (classification.classification == searchedClassification)
            {
                return classification.classificationText;
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
    public WeaponClassification classification;
    
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
    public int bombers;
    public int ah;
    public int aaw;

    
}

[Serializable]
public class ClassificationToString
{
    public string classificationText;
    public WeaponClassification classification;
}

