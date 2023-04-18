
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using strange.extensions.command.impl;
using UnityEngine;

/// <summary>
/// Executed after loading round or user answer.
/// Gets choices for Enemy depending on <see cref="IGameConfig"/>, <see cref="IGameRules"/>
/// and dispatches <see cref="RoundPhaseLoadedSignal"/>
/// </summary>
public class RoundGetPhaseCommand : Command
{
    [Inject]
    public IGameConfig gameConfig { get; set; }
    [Inject]
    public IGameRules gameRules { get; set; }

    [Inject] 
    public IUser user { get; set; }

    [Inject] 
    public RoundPhaseLoadedSignal phaseLoadedSignal { get; set; }

    [Inject]
    public IRound round { get; set; }
    
    private static System.Random rng = new System.Random();
    
    public override void Execute()
    {
        IWeapon enemy = GetEnemyForPhase(round);
        
        SetChoices(enemy);

        phaseLoadedSignal.Dispatch(enemy, round.ChoicesWeapons); // TODO add allies for choices
    }

    private IWeapon GetEnemyForPhase(IRound r)
    {
        return r.GetNextEnemy();
    }

    private void SetChoices(IWeapon enemy)
    {
        var dictionaryChoices = GetListOfChoices(enemy);
        for (int i = 0; i < gameRules.GetChoicesQuantityForRound(); i++)
        {
            round.SetChoice(i+1, dictionaryChoices[i]);
        }

        round.CorrectChoice = round.ChoicesWeapons[1];

        // Mix  Dictionary
        // System.Random rand = new System.Random();
        // origin = origin.OrderBy(x => rand.Next())
        //     .ToDictionary(item => item.Key, item => item.Value);
    }

    /// <summary>
    /// First choice here is correct.
    /// </summary>
    /// <param name="enemy"></param>
    /// <returns>List of IWeapon with size got from <see cref="IGameRules"/></returns>
    private List<IWeapon> GetListOfChoices(IWeapon enemy)
    {
        var choices = new List<IWeapon> ();
        IWeapon correct = FindCorrect(enemy);

        List<IWeapon> incorrect = FindIncorrect(enemy);


        choices.Add(correct);
        choices.AddRange(incorrect);
        Debug.Log($"[RoundGetPhaseCmd] Found weapons:" +
                  $"\n correct: [{correct.Name}]" +
                  $"\n incorrect: [{incorrect.Aggregate("", (s, weapon) => s + $"{weapon.Name}, ")}]");

        return choices;
    }
    
    private IWeapon FindCorrect(IWeapon enemy)
    {
        Dictionary<WeaponTyping, int> counterTyping = gameRules.GetCounterWeaponsPower(enemy.Type);

        // These type (MBT for example) is the best
        // TODO make it dependent on Years of weapon and include that too
        WeaponTyping weaponTyping = GetRandomBestCounterWeaponType(counterTyping);
        
        var suitableWeapons = user.inventory.alliesList.FindAll(e => e.weapon.Type == weaponTyping);

        var debug = suitableWeapons.Aggregate("", (current, inventoryElement) => current + $"{inventoryElement.weapon.Name},\n");
        Debug.Log($"[RoundGetPhaseCmd] SuitableWeapons for {weaponTyping} are: " + debug);
        
        return suitableWeapons.OrderBy(a => rng.Next()).ToList()[0].weapon;
    }

    // remark: Find COrrect and Incorrect can be abstracted to Find (bool isCorrect) with return Type List<IWeapon>
    // than from correct will be obtained first (or random)
    // from incorrect will be obtained range of others (or only 1)
    
    private List<IWeapon> FindIncorrect(IWeapon enemy)
    {
        Dictionary<WeaponTyping, int> counterTyping = gameRules.GetCounterWeaponsPower(enemy.Type);

        List<WeaponTyping> incorrectTypings = FindAllIncorrectTypings(counterTyping);

        List<IInventoryElement> suitableIncorrectWeapons = new List<IInventoryElement>();
        
        foreach (var typing in incorrectTypings)
        {
            suitableIncorrectWeapons.AddRange(user.inventory.alliesList.FindAll(e => e.weapon.Type == typing));
        }
        
        var incorrectWeapons = suitableIncorrectWeapons.OrderBy(a => rng.Next()).ToList();

        var debug = incorrectWeapons.Aggregate("", (current, inventoryElement) => current + $"{inventoryElement.weapon.Name},\n");
        Debug.Log($"[RoundGetPhaseCmd] SuitableIncorrectWeapons for are: " + debug);
        
        var result = new List<IWeapon>();
        for (int i = 0; i < gameRules.GetChoicesQuantityForRound(); i++)
        {
            result.Add(incorrectWeapons[i].weapon);
        }

        return result;
    }

    private WeaponTyping GetRandomBestCounterWeaponType(Dictionary<WeaponTyping, int> counterTyping)
    {
        string debug = "minimal powers have these types: ";
        int minimalWeaponPower = gameConfig.GetMinimalWeaponPowerForRound();
        
        var minimalBestTypings = new List<WeaponTyping>();
        foreach (var i in counterTyping)
        {
            if (i.Value >= minimalWeaponPower)
            {
                debug += $"[{Enum.GetName(typeof(WeaponTyping), i.Key)}, {i.Value}] ";
                minimalBestTypings.Add(i.Key);
            }
        }
        
        Debug.Log("[RoundGetPhaseCmd] GetRndCounterWeaponTypes: " + debug);
        
        return minimalBestTypings.OrderBy(a => rng.Next()).ToList()[0];
    }
    
    /// <remarks>
    /// Need to refactor for questions with 4-6 variants of answer
    /// </remarks>
    /// <param name="counterTyping"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    private List<WeaponTyping> FindAllIncorrectTypings(Dictionary<WeaponTyping, int> counterTyping)
    {
        string debug = "other powers have these types: ";
        int minimalWeaponPower = gameConfig.GetMinimalWeaponPowerForRound();
        
        var otherTypings = new List<WeaponTyping>();
        foreach (var i in counterTyping)
        {
            if (i.Value < minimalWeaponPower)
            {
                debug += $"[{Enum.GetName(typeof(WeaponTyping), i.Key)}, {i.Value}] ";
                otherTypings.Add(i.Key);
            }
        }
        Debug.Log("[RoundGetPhaseCmd] GetRndCounterWeaponTypes: " + debug);
        
        // Attention:
        if (otherTypings.Capacity < gameRules.GetChoicesQuantityForRound())
        {
            Debug.LogError($"We have weapon that has less than {gameRules.GetChoicesQuantityForRound()} incorrect variants of Weapon Typing");
            throw new NotImplementedException();
            // the list can be duplicated and aggregated with itself, so that could be more variants
        }
        
        return otherTypings.OrderBy(a => rng.Next()).ToList();
    }
}

class RoundGetPhaseCommand_Debug : RoundGetPhaseCommand
{
    public override void Execute()
    {
        Debug.LogWarning("[RGPCmd] Execution");
        base.Execute();
    }
}
