

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponData", order = 2)]
public class DataScriptableObject : ScriptableObject
{
    private List<IWeapon> weaponModels;
    
    public WeaponSide side;
    public List<WeaponsOfTypeDataObject> dataWeapons;
    public List<IWeapon> GetWeapons()
    {
        weaponModels = new List<IWeapon>();
        foreach (var weapon in dataWeapons)
        {
            foreach (var model in weapon.weapons)
            {
                weaponModels.Add(model);
            }
        }
        return weaponModels;
    }
}

[Serializable]
public class WeaponsOfTypeDataObject
{
    [NotEditable]
    public string typeName;
    public WeaponTyping typing;
    public List<WeaponModel> weapons;
}



