
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Depracated
/// </summary>
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponDataScriptableObject : ScriptableObject
{
    public List<WeaponModel> mbt;
    [Space(10)]
    public List<WeaponModel> mlrs;
    [Space(10)]
    public List<WeaponModel> apc;
    [FormerlySerializedAs("afv")] [Space(10)]
    public List<WeaponModel> ifv;
    [Space(10)]
    public List<WeaponModel> uav;
    [Space(10)]
    public List<WeaponModel> sph;
    [Space(10)]
    public List<WeaponModel> aaw;
    [Space(10)]
    public List<WeaponModel> towed;
    [Space(10)]
    public List<WeaponModel> fighters;
    [Space(10)]
    public List<WeaponModel> bombers;
    [FormerlySerializedAs("helicopters")] [Space(10)]
    public List<WeaponModel> ah;

    public List<IWeapon> GetWeapons()
    {
        List<IWeapon> list = new List<IWeapon>();
        list.AddRange(mbt);
        list.AddRange(mlrs);
        list.AddRange(apc);
        list.AddRange(ifv);
        list.AddRange(uav);
        list.AddRange(sph);
        list.AddRange(towed);
        list.AddRange(fighters);
        list.AddRange(bombers);
        list.AddRange(ah);
        list.AddRange(aaw);

        return list;
    }
}
