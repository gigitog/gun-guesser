using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

public class GenerateScriptableObjectsCommand : MonoBehaviour
{
    private static readonly string startpath = "jsonFiles/Enemies/";
    
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

    [MenuItem("GameObject/Create Enemies Scriptable Object")]
    public static void CreateEnemies()
    {
        // Create a Weapon Data Scriptable Object
        WeaponDataScriptableObject enemies = ScriptableObject.CreateInstance<WeaponDataScriptableObject>();
        enemies.mbt = new List<WeaponModel>();
        enemies.mbt = new List<WeaponModel>();
        enemies.mlrs = new List<WeaponModel>();
        enemies.apc = new List<WeaponModel>();
        enemies.ifv = new List<WeaponModel>();
        enemies.uav = new List<WeaponModel>();
        enemies.sph = new List<WeaponModel>();
        enemies.towed = new List<WeaponModel>();
        enemies.fighters = new List<WeaponModel>();
        enemies.bombers = new List<WeaponModel>();
        enemies.ah = new List<WeaponModel>();
        enemies.aaw = new List<WeaponModel>();
        
        SetWeapons(enemies.mbt, mbt, WeaponTyping.MBT, WeaponClassification.Ground);
        SetWeapons(enemies.mlrs, mlrs, WeaponTyping.MLRS, WeaponClassification.Ground);
        SetWeapons(enemies.apc, apc, WeaponTyping.APC, WeaponClassification.Ground);
        SetWeapons(enemies.ifv, ifv, WeaponTyping.IFV, WeaponClassification.Ground);
        SetWeapons(enemies.uav, uav, WeaponTyping.UAV, WeaponClassification.Air);
        SetWeapons(enemies.sph, sph, WeaponTyping.SPH, WeaponClassification.Ground);
        SetWeapons(enemies.towed, towed, WeaponTyping.Towed, WeaponClassification.Ground);
        SetWeapons(enemies.fighters, fighter, WeaponTyping.Fighter, WeaponClassification.Air);
        SetWeapons(enemies.bombers, bomber, WeaponTyping.Bomber, WeaponClassification.Air);
        SetWeapons(enemies.ah, ah, WeaponTyping.AH, WeaponClassification.Air);
        SetWeapons(enemies.aaw, aaw, WeaponTyping.AAW, WeaponClassification.Ground);

        // create asset
        AssetDatabase.CreateAsset(enemies, "Assets/Resources/EnemyWeaponData.asset");
    }

    private static void SetWeapons(List<WeaponModel> enemiesType, string path, WeaponTyping typing, WeaponClassification classification)
    {
        var weapons = GetWeapons(path);
        foreach (var weapon in weapons)
        {
            var w = new WeaponModel
            {
                Name = weapon.name,
                Year = weapon.year.ToString(),
                Country = weapon.country,
                Description = weapon.description,
                Side = WeaponSide.Enemy,
                Type = typing,
                WeaponClass = classification
            };
            enemiesType.Add(w);
        }
    }

    private static List<WeaponJsonObject> GetWeapons(string path)
    {
        var json = Resources.Load<TextAsset>(startpath + path);
        Debug.Log(json == null);
        return JsonConvert.DeserializeObject<List<WeaponJsonObject>>(json.text);
    }
}

public class WeaponJsonObject
{
    public string name { get; set; }
    public int year { get; set; }
    public string country { get; set; }
    public string description { get; set; }
}