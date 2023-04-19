
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using strange.extensions.command.impl;
using UnityEngine;
using Console = UnityEngine.Console;

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

    protected string debugResult;
    
    private static System.Random rng = new System.Random();
    
    public override void Execute()
    {
        IWeapon enemy = GetEnemyForPhase(round);
        
        SetChoices(enemy);

        phaseLoadedSignal.Dispatch(enemy, round.ChoicesWeapons, round.RoundStats); // TODO add allies for choices
    }

    private IWeapon GetEnemyForPhase(IRound r)
    {
        return r.GetNextEnemy();
    }

    private void SetChoices(IWeapon enemy)
    {
        var choicesList = GetListOfChoices(enemy);
        
        var mixedChoices = choicesList.OrderBy(a => rng.Next()).ToList();
        for (int i = 0; i < gameRules.GetChoicesQuantityForRound(); i++)
        {
            round.SetChoice(i+1, mixedChoices[i]);
        }
        
        // Mix  Dictionary
        // System.Random rand = new System.Random();
        
    }

    /// <summary>
    /// First choice here is correct.
    /// </summary>
    /// <param name="enemy"></param>
    /// <returns>List of IWeapon with size got from <see cref="IGameRules"/></returns>
    private List<IWeapon> GetListOfChoices(IWeapon enemy)
    {
        var choices = new List<IWeapon>();
        
        var correct = FindCorrect(enemy);
        choices.Add(correct);
        round.CorrectChoice = correct;
        
        var incorrect = FindIncorrect(enemy);
        choices.AddRange(incorrect);

        debugResult += $"\nFound weapons:" +
                       $"\n - correct: [{correct.Name}]" +
                       $"\n - incorrect: [{incorrect.Aggregate("", (s, weapon) => s + $"{weapon.Name}, ")}]";
        return choices;
    }
    
    private IWeapon FindCorrect(IWeapon enemy)
    {
        Dictionary<WeaponTyping, int> counterTyping = gameRules.GetCounterWeaponsPower(enemy.Type);

        // These type (MBT for example) is the best
        // TODO make it dependent on Years of weapon and include that too
        WeaponTyping weaponTyping = GetRandomBestCounterWeaponType(counterTyping);
        
        var suitableWeapons = user.inventory.alliesList.FindAll(e => e.weapon.Type == weaponTyping);

        var debug = suitableWeapons.Aggregate("", (current, inventoryElement) => current + $"\"{inventoryElement.weapon.Name}\", ");
        debugResult += $"\nsuitableWeapons for {weaponTyping} are: [{debug}]";
        
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

        var debug = incorrectWeapons.Aggregate("", (current, inventoryElement) => current + $"\"{inventoryElement.weapon.Name}\", ");
        debugResult += $"\nIncorrect suitableWeapons for are: [{debug}] ";
        
        var result = new List<IWeapon>();
        // minus one as soon as 1 choice is for correct
        for (int i = 0; i < gameRules.GetChoicesQuantityForRound() - 1; i++)
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
        int c = 0;
        foreach (var i in counterTyping)
        {
            if (i.Value >= minimalWeaponPower)
            {
                c++;
                debug += $"[{Enum.GetName(typeof(WeaponTyping), i.Key)}, {i.Value}] ";
                minimalBestTypings.Add(i.Key);
            }
        }

        if (c == 0) Console.LogError("RGPCmd",$"No Minimal weapon for power [{gameConfig.GetMinimalWeaponPowerForRound()}]");

        debugResult += "\nGetRndCounterWeaponTypes: " + debug;
        
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

        debugResult += "\n[RGPCmd] GetAllIncorrectWeaponTypes: " + debug;
        
        // Attention:
        if (otherTypings.Capacity < gameRules.GetChoicesQuantityForRound())
        {
            Console.LogError("RGPCmd",$"We have weapon that has less than {gameRules.GetChoicesQuantityForRound()} incorrect variants of Weapon Typing");
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
        int phases = gameRules.GetPhasesQuantityForRound();
        Console.LogWarning("RGPCmd",$"Execution. Loading phase [{phases - round.GetEnemiesQuantity() + 1}/{phases}]");
        base.Execute();
        // TODO LogProblem
        Console.LogWarning("RGPCmd",$"End with debug:\nCorrect: [{round.CorrectChoice.Name}] {debugResult}");
    }
}
