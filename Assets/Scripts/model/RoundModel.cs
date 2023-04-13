using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoundModel : IRound
{
    public bool IsPlaying { get; private set; }
    public Queue<IWeapon> Weapons { get; set; }
    
    [Inject]
    public IWeapon Card { get; set; }

    public short RoundNumber { get; set; }
    public void SetPhases(List<IWeapon> list)
    {
        string enemiesString = list.Aggregate("", (current, weapon) => current + " - " + weapon.Name + "\n");
        
        Debug.Log("[RoundModel]: Set Enemies (Phases) for Round: \n" + enemiesString);

        Weapons = new Queue<IWeapon>(list);
    }
}