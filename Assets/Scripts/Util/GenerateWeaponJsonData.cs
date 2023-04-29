using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Util
{
    /// <summary>
    /// Generator of <see cref="WeaponsOfTypeDataObject"/> from Json files in <see cref="PathFinder"/>.
    /// Jsons are based on <see cref="WeaponJsonObject"/>
    /// </summary>
    public static class GenerateWeaponJsonData
    {
        public static void CreateWeapons(List<WeaponsOfTypeDataObject> weaponsToFill, WeaponSide weaponSide)
        {
            foreach (var dataWeapons in weaponsToFill)
            {
                dataWeapons.weapons = GetWeaponModels(new WeaponModel(weaponSide, dataWeapons.typing));
            }
        }

        private static List<WeaponModel> GetWeaponModels(IWeapon blueprint)
        {
            var weapons = new List<WeaponModel>();
            var jsonWeapons = GetWeapons(blueprint.Side, blueprint.Type);
        
            foreach (var jsonWeapon in jsonWeapons)
            {
                var w = new WeaponModel
                {
                    Name = jsonWeapon.name,
                    Year = jsonWeapon.year.ToString(),
                    Country = jsonWeapon.country,
                    Description = jsonWeapon.description,
                
                    Side = blueprint.Side,
                    Type = blueprint.Type,
                    WeaponMobility = blueprint.WeaponMobility
                };
                weapons.Add(w);
            }

            return weapons;
        }


        private static List<WeaponJsonObject> GetWeapons(WeaponSide side, WeaponTyping typing)
        {
            var json = Resources.Load<TextAsset>(PathFinder.GetFullPath(side, typing));

            if (json != null) 
                return JsonConvert.DeserializeObject<List<WeaponJsonObject>>(json.text);
        
            Console.LogWarning("GenerateWeaponJsonData",$"{PathFinder.GetFullPath(side, typing)} do not exist!");
        
            var s = new List<WeaponJsonObject>();
            s.Add(new WeaponJsonObject());
        
            return s;
        }
    }

    /// <summary>
    /// Model of Json object of Weapon. 
    /// </summary>
    public class WeaponJsonObject
    {
        public string name { get; set; }
        public int year { get; set; }
        public string country { get; set; }
        public string description { get; set; }
    }
}