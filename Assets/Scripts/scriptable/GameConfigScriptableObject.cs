using System;
using System.Collections.Generic;
using strange.extensions.injector.api;
using UnityEngine;
using Util;

/// <summary>
/// Game Config Scriptable Object is a Unity-specified object to
/// store and modify data in the Unity editor. Derives from <see cref="IGameConfig"/> <br/>
/// Stores a bunch of serialized fields to easily edit in Unity editor
/// <remarks>Game Design</remarks>
/// </summary>
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameConfig", order = 1)]
public class GameConfigScriptableObject : ScriptableObject, IGameConfig
{
    [Header("Weapon Data")]
    [SerializeField] private DataScriptableObject weaponAlliesData;
    [SerializeField] private DataScriptableObject weaponEnemyData;
    
    [Header("Weapon Config")]
    [SerializeField] private WeaponConfigScriptableObject weaponConfig;

    [Header("General Logic")] 
    [Range(1, 5)]
    [SerializeField] private short maxHearts;
    [SerializeField] private short heartRefillTimeSeconds;
    
    [Header("User Logic")]
    [SerializeField] private int experienceEasyRound;
    [SerializeField] private int baseNumberOfRoundsForLevel;
    [SerializeField] private int experienceHardMultiplier;
    
    [Header("Inventory Logic")]
    [SerializeField] private int baseNumberNewWeaponsPerLevel;

    [Header("Round Logic")]
    [Tooltip("for [7] means that for counter weapon for enemy could be chosen a weapon with 7 (70%) chance to win")] [Range(7, 9)] [SerializeField] private int minimalWeaponPower;
    [Range(4, 12)] [SerializeField] private int defaultPhasesPerRound;
    [Range(3, 12)] [SerializeField] private int baseTimeForCard;
    [Range(4, 20)] [SerializeField] private int defaultPhaseQuantity;
    [Range(2, 6)] [SerializeField] private int defaultChoicesQuantity;

    [Space(10)]
    [Header("User Interface Prefabs")]
    [SerializeField] private GameObject inventoryElementPrefab;

    public List<IWeapon> WeaponAlliesData => weaponAlliesData.GetWeapons();
    public List<IWeapon> WeaponEnemyData => weaponEnemyData.GetWeapons();
    public GameObject InventoryElementPrefab => inventoryElementPrefab;

    public int GetDefaultChoicesQuantity() => defaultChoicesQuantity;

    public int GetMinimalWeaponPowerForRound()
    {
        return minimalWeaponPower;
    }

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

    /// <summary>
    /// Returns Time for Round based on quantity of enemies for this round and difficulty <br/>
    /// Now it's a hardcoded thing, very bad code, must be refactored later.
    /// </summary>
    /// <param name="userLevelNumber"></param>
    /// <returns></returns>
    public int GetDefaultTimeForRound(long userLevelNumber)
    {
        return baseTimeForCard * defaultPhasesPerRound;
    }

    public short GetXpForLevel(long userLevelNumber)
    {
        throw new System.NotImplementedException();
    }

    public int GetHeartsRefillTime()
    {
        throw new System.NotImplementedException();
    }

    public int GetDefaultPhasesQuantityForRound() => defaultPhaseQuantity;

    public string GetTextType(WeaponTyping typing) => weaponConfig.GetShortType(typing);

    public string GetTextTypeLong(WeaponTyping typing) => weaponConfig.GetFullType(typing);

    public string GetTextMobility(WeaponMobility mobility) => weaponConfig.GetMobilityType(mobility);
    public Sprite GetImageMobility(WeaponMobility mobility) => weaponConfig.GetMobilityImage(mobility);
    public Sprite GetImageCountry(CountryNames countryCode) => weaponConfig.GetImageCountry(countryCode);

    public string GetTextStage(int stage) => stage.ToString();

    public string GetTextSide(WeaponSide side)
    {
        return $"{Enum.GetName(typeof(WeaponSide), side)}";
    }

    public Sprite GetEnemySprite(WeaponTyping typing)
    {
        var weapon = weaponConfig.weapons.Find(w => w.typing == typing);
        return weapon.defaultSprite;
    }

    public Sprite GetAlliesSprite(WeaponTyping typing)
    {
        var weapon = weaponConfig.weapons.Find(w => w.typing == typing);
        return weapon.defaultSprite;
    }

    public Dictionary<WeaponTyping, int> GetCounterTypingPower(WeaponTyping weapon)
    {
        return weaponConfig.GetCounterWeaponsDictionary(weapon);
    }
}