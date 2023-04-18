
using System;
using System.Collections.Generic;
using strange.extensions.injector.api;
using UnityEngine;

/// <summary>
/// Game Rules interface aim is to provide application an access to <br/>
/// - Initial Inventory of a New <see cref="IUser"/> <br/>
/// - Get Enemies for round depending on User's data <br/>
/// - Get choices for Phase depending on User's data <br/>
/// </summary>
public interface IGameRules
{
    public IInventory GetInitialInventory();

    /// <summary>
    /// It returns random N enemies, N = <see cref="GetPhasesQuantityForRound"/>
    /// </summary>
    /// <remarks>Implementation will probably be changed (N = 5)</remarks>
    /// <returns>List of <see cref="IWeapon"/></returns>
    public List<IWeapon> GetEnemiesForRound();
    
    public Dictionary<WeaponTyping, int> GetCounterWeaponsPower(WeaponTyping typing);
    /// <summary>
    /// Returns Default Phases Quantity from <see cref="IGameConfig"/><br/>
    /// </summary>
    /// <remarks>
    /// Implementation will probably be changed <br/>
    /// For game design in future it's planned to expand number of phases for more difficulty.
    /// </remarks>
    /// <returns>int value of phases' quantity (=5 MVP)</returns>
    public int GetPhasesQuantityForRound();
    /// <summary>
    /// Gets quantity of choices from 2 to 6 in the perspective.
    /// <para> Yet it is only two choices in return.</para>
    /// </summary>
    /// <returns>int value (=2 MVP)</returns>
    public int GetChoicesQuantityForRound();
    public bool MatchWeaponTypes(IWeapon enemy, IWeapon weapon);
    public int GetTimeForRound();
}


/// <summary>
/// Realization of <see cref="IGameRules"/> <br/>
/// Injected: <br/>
/// - <see cref="IInjectionBinder"/> <br/>
/// - <see cref="IGameConfig"/> <br/>
/// - <see cref="IUser"/> <br/>
/// </summary>
class GameRulesModel : IGameRules
{
    [Inject]
    public IInjectionBinder injectionBinder{ get; set; }
    [Inject] 
    public IGameConfig gameConfig { get; set; }
    [Inject]
    public IUser user { get; set; }
    
    public IInventory GetInitialInventory()
    {
        var init = injectionBinder.GetInstance<IInventory>() as IInventory;
        init.inventoryList = new List<IInventoryElement>();
        AddInitWeapons(init, gameConfig.WeaponAlliesData);
        AddInitWeapons(init, gameConfig.WeaponEnemyData);
        return init;
    }

    public Dictionary<WeaponTyping, int> GetCounterWeaponsPower(WeaponTyping typing)
    {
        return gameConfig.GetCounterTypingPower(typing);
    }

    public int GetPhasesQuantityForRound()
    {
        return gameConfig.GetDefaultPhasesQuantityForRound();
    }
    
    public int GetChoicesQuantityForRound()
    {
        return gameConfig.GetDefaultChoicesQuantity();
    }

    public bool MatchWeaponTypes(IWeapon enemy, IWeapon weapon)
    {
        return false;
    }

    public int GetTimeForRound()
    {
        return gameConfig.GetDefaultTimeForRound(user.Level);
    }


    public List<IWeapon> GetEnemiesForRound()
    {
        System.Random random = new System.Random();
        List<IInventoryElement> inventoryEnemies = user.inventory.enemiesList;
        List<IWeapon> resultEnemies = new List<IWeapon>();
        
        for (int i = 0; i < GetPhasesQuantityForRound(); i++)
        {
            var w = inventoryEnemies[random.Next(0, inventoryEnemies.Count)].weapon;
            resultEnemies.Add(w);
        }
        
        return resultEnemies;
    }
    
    private static void AddInitWeapons(IInventory init, List<IWeapon> listFromToAdd)
    {
        foreach (WeaponTyping typ in Enum.GetValues(typeof(WeaponTyping)))
        {
            init.AddWeaponToInventory(listFromToAdd.Find(w => w.Type == typ));
        }
    }
}
