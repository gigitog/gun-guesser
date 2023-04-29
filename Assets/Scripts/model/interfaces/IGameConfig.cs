
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game Configuration interface aim is to provide application an access to <br/>
/// - all data of weapons (<see cref="IWeapon"/>) <br/>
/// - Game Design information about <see cref="IRound"/> and its Phases <br/>
/// - Get Default Sprites of weapons <br/>
/// - Get text equivalents of <see cref="WeaponTyping"/>, <see cref="WeaponMobility"/>
/// </summary>
public interface IGameConfig
{
    public List<IWeapon> WeaponAlliesData { get;}
    public List<IWeapon> WeaponEnemyData { get;}
    
    public GameObject InventoryElementPrefab { get; }
    
    public int GetHeartsRefillTime();

    public int GetDefaultPhasesQuantityForRound();

    public int GetDefaultChoicesQuantity();
    public int GetDefaultTimeForRound(long userLevelNumber);


    /// <summary>
    /// For "Easy" minimal weapon power is 7-10.
    /// <para>Min power is set for the whole round.</para>
    /// </summary>
    /// <returns>int value of power</returns>
    public int GetMinimalWeaponPowerForRound();

    public int GetNumberNewWeapons(long userLevelNumber);

    public short GetXpForLevel(long userLevelNumber);

    public string GetTextType(WeaponTyping typing);
    public string GetTextTypeLong(WeaponTyping typing);
    public string GetTextMobility(WeaponMobility mobility);
    // TODO config.GetInventoryElementStage(data.weapon.Stage);
    public string GetTextStage(int stage);
    public string GetTextSide(WeaponSide side);
    public Sprite GetEnemySprite(WeaponTyping typing);
    public Sprite GetAlliesSprite(WeaponTyping typing);
    public Dictionary<WeaponTyping, int> GetCounterTypingPower(WeaponTyping weapon);
}
