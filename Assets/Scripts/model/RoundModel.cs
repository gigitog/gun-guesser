using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class RoundModel : IRound
{
    private Queue<IWeapon> weapons;
    private float time;
    private int choicesQuantity;

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

    public short RoundNumber { get; set; }


    public void SetDefaultRound(List<IWeapon> enemies, int timeSeconds, int choicesQuantity)
    {
        IsPlaying = true;
        this.choicesQuantity = choicesQuantity;
        time = timeSeconds;
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
        
        Debug.Log("[RoundModel]: Set Enemies (Phases) for Round: \n" + enemiesString);

        weapons = new Queue<IWeapon>(list);
    }

    public IWeapon GetNextEnemy()
    {
        return weapons.Dequeue();
    }

    public int GetEnemiesQuantity()
    {
        return weapons?.Count ?? 0;
    }

}