using System;
using System.Collections.Generic;
using strange.extensions.injector.api;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameConfig", order = 1)]
public class GameConfigScriptableObject : ScriptableObject, IGameConfig
{
    [Inject]
    public IInjectionBinder injectionBinder{ get; set; }
    
    [Header("Weapon Data")]
    [SerializeField] private DataScriptableObject weaponAlliesData;
    [SerializeField] private DataScriptableObject weaponEnemyData;
    
    [Header("Weapon Config")]
    [SerializeField] private WeaponConfigScriptableObject weaponConfig;

    [Header("Game Logic")] 
    [SerializeField] private short maxHearts;
    [SerializeField] private short heartRefillTimeSeconds;
    
    [Header("User Logic")]
    [SerializeField] private int experienceEasyRound;
    [SerializeField] private int baseNumberOfRoundsForLevel;
    [SerializeField] private int experienceHardMultiplier;
    
    [Header("Inventory Logic")]
    [SerializeField] private int baseNumberNewWeaponsPerLevel;

    [Header("Round Logic")]
    [SerializeField] private int baseCardsPerRound;
    [SerializeField] private int baseTimeForCard;
    
    [Space(10)]
    [Header("User Interface Prefavs")]
    [SerializeField] private GameObject roundInterfacePrefab;

    public List<IWeapon> WeaponAlliesData => weaponAlliesData.GetWeapons();
    public List<IWeapon> WeaponEnemyData => weaponEnemyData.GetWeapons();
    public GameObject RoundInterfacePrefab => roundInterfacePrefab;

    public int GetNumberOfPhases(long userLevelNumber) => baseCardsPerRound;

    public int GetNumberNewWeapons(long userLevelNumber)
    {
        if (userLevelNumber < 10)
            return 1;

        if (userLevelNumber < 20)
            return 2;

        if (userLevelNumber < 30)
            return 3;

        return 4;
    }

    public int GetTimeForCard(long userLevelNumber)
    {
        throw new System.NotImplementedException();
    }

    public short GetXpForLevel(long userLevelNumber)
    {
        throw new System.NotImplementedException();
    }

    public IInventory GetInitialInventory()
    {
        var init = injectionBinder.GetInstance<IInventory>() as IInventory;
        init.inventoryList = new List<IInventoryElement>();
        AddInitWeapons(init, WeaponAlliesData);
        AddInitWeapons(init, WeaponEnemyData);
        return init;
    }

    private static void AddInitWeapons(IInventory init, List<IWeapon> listFromToAdd)
    {
        foreach (WeaponTyping typ in Enum.GetValues(typeof(WeaponTyping)))
        {
            init.AddWeaponToInventory(listFromToAdd.Find(w => w.Type == typ));
            // foreach (var weapon in listFromToAdd)
            // {
            //     if (weapon.Type == typ)
            //     {
            //         init.AddWeaponToInventory(weapon);
            //         Debug.Log($"[GameCfg] AddEnemy:\n" +
            //                   $"  Linq: {listFromToAdd.Find(w => w.Type == typ).Name}\n" +
            //                   $"  Fore:{weapon.Name}");
            //         break;
            //     }
            // }
        }
    }

    public int GetHeartsRefillTime()
    {
        throw new System.NotImplementedException();
    }

    public string GetTextType(WeaponTyping typing) => weaponConfig.GetShortType(typing);

    public string GetTextTypeLong(WeaponTyping typing) => weaponConfig.GetFullType(typing);

    public string GetTextClassification(WeaponMobility mobility) => weaponConfig.GetMobilityType(mobility);

    public Sprite GetEnemySprite(WeaponTyping typing)
    {
        throw new System.NotImplementedException();
    }

    public Sprite GetAlliesSprite(WeaponTyping typing)
    {
        throw new System.NotImplementedException();
    }

    public bool MatchWeaponTypes(IWeapon enemy, IWeapon weapon)
    {
        return false;
    }

    public List<IWeapon> GetEnemiesForRound(IUser user)
    {
        System.Random random = new System.Random();
        List<IInventoryElement> inventoryEnemies = user.inventory.enemiesList;
        List<IWeapon> resultEnemies = new List<IWeapon>();
        string enemiesString = "";
        
        for (int i = 0; i < GetNumberOfPhases(user.Level); i++)
        {
            var w = inventoryEnemies[random.Next(0, inventoryEnemies.Count)].weapon;
            resultEnemies.Add(w);
            enemiesString += $"{i+1}: {w.Name}\n";
        }
        
        Debug.Log($"[GameCfgSO]: GetEnemiesForRound:\n" + enemiesString);

        return resultEnemies;
    }
}
