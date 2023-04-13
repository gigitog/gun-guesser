
using System.Collections.Generic;
using strange.extensions.injector.api;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameConfig", order = 1)]
public class GameConfigScriptableObject : ScriptableObject, IGameConfig
{
    [Inject]
    public IInjectionBinder injectionBinder{ get; set; }
    
    [Header("Weapon Data")]
    [SerializeField] private WeaponDataScriptableObject weaponAlliesData;
    [SerializeField] private WeaponDataScriptableObject weaponEnemyData;
    
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

    public WeaponDataScriptableObject WeaponAlliesData => weaponAlliesData;
    public WeaponDataScriptableObject WeaponEnemyData => weaponEnemyData;
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
        init.AddWeaponToInventory(weaponAlliesData.aaw[0]);
        init.AddWeaponToInventory(weaponAlliesData.ifv[0]);
        init.AddWeaponToInventory(weaponAlliesData.apc[0]);
        init.AddWeaponToInventory(weaponAlliesData.mbt[0]);
        init.AddWeaponToInventory(weaponAlliesData.mlrs[0]);
        init.AddWeaponToInventory(weaponAlliesData.towed[0]);
        init.AddWeaponToInventory(weaponAlliesData.sph[0]);
        return init;
    }

    public int GetHeartsRefillTime()
    {
        throw new System.NotImplementedException();
    }

    public string GetTextType(WeaponTyping typing) => weaponConfig.GetShortType(typing);

    public string GetTextTypeLong(WeaponTyping typing) => weaponConfig.GetFullType(typing);

    public string GetTextClassification(WeaponClassification classification) => weaponConfig.GetClassification(classification);

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
            var w = inventoryEnemies[random.Next(inventoryEnemies.Count)].weapon;
            resultEnemies.Add(w);
            enemiesString += $"{i+1}: {w}\n";
        }
        
        Debug.Log($"[GameCfgSO]: GetEnemiesForRound:\n" + enemiesString);

        return resultEnemies;
    }
}
