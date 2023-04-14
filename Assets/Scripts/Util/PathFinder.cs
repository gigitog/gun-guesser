
using System;

public static class PathFinder
{
    private static readonly string startpath = "jsonFiles/";
    private static readonly string enemies = "Enemies/";
    private static readonly string allies = "Allies/";
    
    private static readonly string mbt = "mbt";
    private static readonly string mlrs = "mlrs";
    private static readonly string apc = "apc";
    private static readonly string ifv = "ifv";
    private static readonly string uav = "uav";
    private static readonly string sph = "sph";
    private static readonly string towed = "towed";
    private static readonly string fighter = "fighter";
    private static readonly string bomber = "bomber";
    private static readonly string ah = "ah";
    private static readonly string aaw = "aaw";

    public static string GetFullPath(WeaponSide side, WeaponTyping typing)
    {
        return side == WeaponSide.Ally ? GetFullPathAllies(typing) : GetFullPathEnemies(typing);
    }
    
    private static string GetFullPathAllies(WeaponTyping typing)
    {
        return startpath + allies + GetEndPathByType(typing);
    }
    
    private static string GetFullPathEnemies(WeaponTyping typing)
    {
        return startpath + enemies + GetEndPathByType(typing);
    }
    
    private static string GetEndPathByType(WeaponTyping typing)
    {
        return typing switch
        {
            WeaponTyping.MBT =>  mbt,
            WeaponTyping.MLRS => mlrs,
            WeaponTyping.APC => apc,
            WeaponTyping.IFV =>  ifv,
            WeaponTyping.UAV =>  uav,
            WeaponTyping.SPH =>  sph,
            WeaponTyping.Towed => towed,
            WeaponTyping.Fighter => fighter,
            WeaponTyping.Bomber => bomber,
            WeaponTyping.AH => ah,
            WeaponTyping.AAW => aaw,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
