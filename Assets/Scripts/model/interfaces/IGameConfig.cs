
using System.Collections.Generic;
using UnityEngine;

public interface IGameConfig
{
    public List<IWeapon> WeaponAlliesData { get;}
    public List<IWeapon> WeaponEnemyData { get;}
    
    public GameObject RoundInterfacePrefab { get; }
    
    public IInventory GetInitialInventory();

    public List<IWeapon> GetEnemiesForRound(IUser user);
    
    public int GetHeartsRefillTime();
    public int GetNumberOfPhases(long userLevelNumber);
    public int GetNumberNewWeapons(long userLevelNumber);
    public int GetTimeForCard(long userLevelNumber);
    
    public short GetXpForLevel(long userLevelNumber);

    public string GetTextType(WeaponTyping typing);
    public string GetTextTypeLong(WeaponTyping typing);
    public string GetTextClassification(WeaponMobility mobility);
    public Sprite GetEnemySprite(WeaponTyping typing);
    public Sprite GetAlliesSprite(WeaponTyping typing);

    public bool MatchWeaponTypes(IWeapon enemy, IWeapon weapon);
}
