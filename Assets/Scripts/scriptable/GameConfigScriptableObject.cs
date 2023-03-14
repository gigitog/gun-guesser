
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameConfigScriptableObject", order = 1)]
public class GameConfigScriptableObject : ScriptableObject, IGameConfig
{
    [Header("Weapon Configs")]
    [SerializeField] private WeaponConfigScriptableObject weaponAlliesConfig;
    [SerializeField] private WeaponConfigScriptableObject weaponEnemyConfig;

    [Header("Text Config")]
    [SerializeField] private TextConfigScriptableObject textConfig;
    
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
    
    
    public WeaponConfigScriptableObject WeaponAlliesConfig => weaponAlliesConfig;
    public WeaponConfigScriptableObject WeaponEnemyConfig => weaponEnemyConfig;
    

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

    public int GetHeartsRefillTime()
    {
        throw new System.NotImplementedException();
    }
    
    public string GetTextType(WeaponTyping typing) => textConfig.GetType(typing);
    public string GetTextClassification(WeaponClassification classification) => textConfig.GetClassification(classification);
}
