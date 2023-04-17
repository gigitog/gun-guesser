
using System.Collections.Generic;

/// <summary>
/// Round interface provides an access to the state of Round, It's data. <br/>
/// <see cref="SetDefaultRound"/> should be executed first in order to
/// start the round. (To fill Round Model with default data of start; <see cref="IsPlaying"/> == true) <br/>
/// <see cref="CleanRound"/> should be executed last in order to clean data of the round. (<see cref="IsPlaying"/> == false) <br/>
/// </summary>
public interface IRound
{
    public bool IsPlaying { get; }
    
    public void SetDefaultRound(List<IWeapon> enemies, int timeSeconds, int choicesQuantity);
    public void CleanRound();
    public IWeapon GetNextEnemy();
    public int GetEnemiesQuantity();
    
    public Dictionary<int, IWeapon> ChoicesWeapons { get; }
    /// <summary>
    /// Set for a phase one choice; choice serial number can be 1-2 (MVP);
    /// </summary>
    /// <param name="choiceSerialNumber"></param>
    /// <param name="weapon"></param>
    public void SetChoice(int choiceSerialNumber, IWeapon weapon);

}
