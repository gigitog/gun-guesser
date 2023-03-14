
using System.Collections.Generic;

public interface IGameConfig
{
    public WeaponConfigScriptableObject WeaponAlliesConfig { get;}
    public WeaponConfigScriptableObject WeaponEnemyConfig { get;}

    public int GetHeartsRefillTime();
    public int GetNumberOfRounds(int userLevelNumber);
    
    public int GetNumberNewWeapons(int userLevelNumber);
    public int GetCardsPerRound(int userLevelNumber);
    public int GetTimeForCard(int userLevelNumber);
    
    public short GetXpForLevel(int userLevelNumber);

    public string GetTextType(WeaponTyping typing);
    public string GetTextClassification(WeaponClassification classification);
}
