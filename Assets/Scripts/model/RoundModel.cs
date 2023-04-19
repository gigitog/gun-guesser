using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class RoundModel : IRound
{
    private Queue<IWeapon> weapons;
    private float time;
    private int choicesQuantity;

    public RoundStatsData RoundStats { get; private set; }
    public bool IsPlaying { get; private set; }
    public IWeapon CorrectChoice { get; set; }

    public Dictionary<int, IWeapon> ChoicesWeapons { get; private set; }

    public void SetChoice(int choiceSerialNumber, IWeapon weapon)
    {
        if (ChoicesWeapons.ContainsKey(choiceSerialNumber))
        {
            ChoicesWeapons[choiceSerialNumber] = weapon;
        }
        else
        {
            ChoicesWeapons.Add(choiceSerialNumber, weapon);
        }
    }
    
    public void SetDefaultRound(List<IWeapon> enemies, int timeSeconds, int choicesQuantity)
    {
        IsPlaying = true;
        this.choicesQuantity = choicesQuantity;
        time = timeSeconds;
        RoundStats = new RoundStatsData() {currentPhaseIndex = 0, phasesQuantity = enemies.Count};
        ChoicesWeapons = new Dictionary<int, IWeapon>();
        SetEnemies(enemies);
    }

    public void CleanRound()
    {
        IsPlaying = false;
        weapons = new Queue<IWeapon>();
    }

    private void SetEnemies(List<IWeapon> list)
    {
        string enemiesString = list.Aggregate("", (current, weapon) => current + " - " + weapon.Name + "\n");
        
        // TODO LogProblem
        Console.Log("RoundModel",$"Set Enemies (Phases) for Round: {enemiesString}");

        weapons = new Queue<IWeapon>(list);
    }

    public IWeapon GetNextEnemy()
    {
        RoundStats.currentPhaseIndex++;
        return weapons.Dequeue();
    }

    public int GetEnemiesQuantity()
    {
        return weapons?.Count ?? 0;
    }

}

public class RoundStatsData
{
    public int currentPhaseIndex;
    public int phasesQuantity;
}