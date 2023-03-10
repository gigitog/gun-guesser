
using System.Collections.Generic;

public interface IGameConfig
{
    public WeaponConfig WeaponAlliesConfig { get;}
    public WeaponConfig WeaponEnemyConfig { get;}

    public int GetHeartsRefillTime();
    public int GetNumberOfRounds(int userLevelNumber);
    
    public int GetNumberNewWeapons(int userLevelNumber);
    public int GetCardsPerRound(int userLevelNumber);
    public int GetTimeForCard(int userLevelNumber);
    
    public short GetXpForLevel(int userLevelNumber);
}
