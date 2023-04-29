using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Util;

/// <summary>
/// Custom Editor makes it easier to observe, modify and add data of Weapons. <br/>
/// Works with <see cref="GenerateWeaponJsonData"/>
/// </summary>
[CustomEditor(typeof(DataScriptableObject)), CanEditMultipleObjects]
public class WeaponDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DataScriptableObject data = (DataScriptableObject) target;
        EditorGUILayout.LabelField($"--- {Enum.GetName(typeof(WeaponSide), data.side)} ---");
        
        base.OnInspectorGUI();
        
        GUILayout.BeginHorizontal();
        
        if (GUILayout.Button($"Fill With {Enum.GetName(typeof(WeaponSide), data.side)} data"))
        {
            data.dataWeapons = FillData(data.side);
        }
        
        GUILayout.Space(20);
        
        if (GUILayout.Button("Set Default data"))
        {
            SetDefault(ref data.dataWeapons);
        }
        
        GUILayout.EndHorizontal();
        
        ValidateSide(data);
        ValidateType(data);
    }

    private static List<WeaponsOfTypeDataObject> FillData(WeaponSide weaponSide)
    {
        var newList = new List<WeaponsOfTypeDataObject>();

        foreach (WeaponTyping typ in Enum.GetValues(typeof(WeaponTyping)))
        {
            newList.Add(new WeaponsOfTypeDataObject()
            {
                weapons = new List<WeaponModel>(),
                typing = typ,
                typeName = Enum.GetName(typeof(WeaponTyping), typ)
            });
        }

        SetDefault(ref newList);

        GenerateWeaponJsonData.CreateWeapons(newList, weaponSide);

        return newList;
    }

    private static void ValidateSide(DataScriptableObject data)
    {
        foreach (var weapon in data.dataWeapons)
        {
            foreach (var model in weapon.weapons)
            {
                model.Side = data.side;
            }
        }
    }

    private static void ValidateType(DataScriptableObject data)
    {
        foreach (var weapon in data.dataWeapons)
        {
            foreach (var model in weapon.weapons)
            {
                model.Type = weapon.typing;

                weapon.typeName = Enum.GetName(typeof(WeaponTyping), weapon.typing);
            }
        }
    }

    private static void SetDefault(ref List<WeaponsOfTypeDataObject> emptyList)
    {
        if (emptyList != null && emptyList.Count != 0) return;
        
        emptyList = new List<WeaponsOfTypeDataObject>();
        
        foreach (WeaponTyping typ in Enum.GetValues(typeof(WeaponTyping)))
        {
            emptyList.Add(new WeaponsOfTypeDataObject()
            {
                weapons = new List<WeaponModel>(),
                typing = typ,
                typeName = Enum.GetName(typeof(WeaponTyping), typ)
            });
        }
    }
}
