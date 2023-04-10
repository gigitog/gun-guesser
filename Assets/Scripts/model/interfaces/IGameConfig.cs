
using System.Collections.Generic;
using UnityEngine;

public interface IGameConfig
{
    public WeaponDataScriptableObject WeaponAlliesData { get;}
    public WeaponDataScriptableObject WeaponEnemyData { get;}
    
    public GameObject RoundInterfacePrefab { get; }
    
    public IInventory GetInitialInventory();

    public int GetHeartsRefillTime();
    public int GetNumberOfRounds(int userLevelNumber);
    
    public int GetNumberNewWeapons(int userLevelNumber);
    public int GetCardsPerRound(int userLevelNumber);
    public int GetTimeForCard(int userLevelNumber);
    
    public short GetXpForLevel(int userLevelNumber);

    public string GetTextType(WeaponTyping typing);
    public string GetTextTypeLong(WeaponTyping typing);
    public string GetTextClassification(WeaponClassification classification);
    public Sprite GetEnemySprite(WeaponTyping typing);
    public Sprite GetAlliesSprite(WeaponTyping typing);

    public bool MatchWeaponTypes(IWeapon enemy, IWeapon weapon);
}
