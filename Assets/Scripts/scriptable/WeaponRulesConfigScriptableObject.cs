using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponRulesConfig", order = 1)]
public class WeaponRulesConfigScriptableObject : ScriptableObject
{
    public List<WeaponTyping> mbt;
    [Space(10)]
    public List<WeaponTyping> mlrs;
    [Space(10)]
    public List<WeaponTyping> apc;
    [Space(10)]
    public List<WeaponTyping> afv;
    [Space(10)]
    public List<WeaponTyping> uav;
    [Space(10)]
    public List<WeaponTyping> sph;
    [Space(10)]
    public List<WeaponTyping> towed;
    [Space(10)]
    public List<WeaponTyping> fighter;
    [Space(10)]
    public List<WeaponTyping> bomber;
    [Space(10)]
    public List<WeaponTyping> helicopter;
    [Space(10)]
    public List<WeaponTyping> aaw;

    public bool CompareWeapons(IWeapon enemy, IWeapon weapon)
    {
        List<WeaponTyping> weaponsAgainstEnemy = enemy.Type switch
        {
            WeaponTyping.MBT => mbt,
            WeaponTyping.MLRS => mlrs,
            WeaponTyping.APC => apc,
            WeaponTyping.AFV => afv,
            WeaponTyping.UAV => uav,
            WeaponTyping.SPH => sph,
            WeaponTyping.Towed => towed,
            WeaponTyping.Fighter => fighter,
            WeaponTyping.Bomber => bomber,
            WeaponTyping.AH => helicopter,
            WeaponTyping.AAW => aaw,
            _ => throw new ArgumentOutOfRangeException()
        };

        foreach (var weaponTyping in weaponsAgainstEnemy)
        {
            if (weapon.Type == weaponTyping)
            {
                return true;
            }
        }

        return false;
    }
}
