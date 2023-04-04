
using System.Collections.Generic;
using strange.extensions.injector.api;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameConfig", order = 1)]
public class GameConfigScriptableObject : ScriptableObject, IGameConfig
{
    [Inject]
    public IInjectionBinder injectionBinder{ get; set; }
    
    [Header("Weapon Configs")]
    [SerializeField] private WeaponConfigScriptableObject weaponAlliesConfig;
    [SerializeField] private WeaponConfigScriptableObject weaponEnemyConfig;
    [SerializeField] private WeaponRulesConfigScriptableObject weaponRulesConfig;

    [Header("Text Config")]
    [SerializeField] private TextConfigScriptableObject textConfig;

    [Header("Sprite Config")] [SerializeField]
    private SpriteConfigScriptableObject spriteConfig;

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


    public WeaponConfigScriptableObject WeaponAlliesConfig => weaponAlliesConfig;
    public WeaponConfigScriptableObject WeaponEnemyConfig => weaponEnemyConfig;
    public GameObject RoundInterfacePrefab => roundInterfacePrefab;

    public int GetNumberOfRounds(int userLevelNumber)
    {
        throw new System.NotImplementedException();
    }

    public int GetNumberNewWeapons(int userLevelNumber)
    {
        throw new System.NotImplementedException();
    }

    public int GetCardsPerRound(int userLevelNumber)
    {
        throw new System.NotImplementedException();
    }

    public int GetTimeForCard(int userLevelNumber)
    {
        throw new System.NotImplementedException();
    }

    public short GetXpForLevel(int userLevelNumber)
    {
        throw new System.NotImplementedException();
    }

    public IInventory GetInitialInventory()
    {
        var init = injectionBinder.GetInstance<IInventory>() as IInventory;
        init.inventoryList = new List<IInventoryElement>();
        init.AddWeaponToInventory(weaponAlliesConfig.aaw[0]);
        init.AddWeaponToInventory(weaponAlliesConfig.afv[0]);
        init.AddWeaponToInventory(weaponAlliesConfig.apc[0]);
        init.AddWeaponToInventory(weaponAlliesConfig.mbt[0]);
        init.AddWeaponToInventory(weaponAlliesConfig.mlrs[0]);
        init.AddWeaponToInventory(weaponAlliesConfig.towed[0]);
        init.AddWeaponToInventory(weaponAlliesConfig.sph[0]);
        return init;
    }

    public int GetHeartsRefillTime()
    {
        throw new System.NotImplementedException();
    }
    
    public string GetTextType(WeaponTyping typing) => textConfig.GetType(typing);
    public string GetTextTypeLong(WeaponTyping typing) => textConfig.GetLongType(typing);
    public string GetTextClassification(WeaponClassification classification) => textConfig.GetClassification(classification);
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
        return weaponRulesConfig.CompareWeapons(enemy, weapon);
    }
}
