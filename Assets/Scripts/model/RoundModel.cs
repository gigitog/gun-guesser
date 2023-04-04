using System.Collections.Generic;
using UnityEngine;

public class RoundModel : IRound
{
    public bool IsPlaying { get; private set; }
    public Queue<IWeapon> Weapons { get; set; }
    
    [Inject]
    public IWeapon Card { get; set; }

    public short RoundNumber { get; set; }
    public void SetWeapons(List<IWeapon> list)
    {
        Debug.Log("RoundModel: Set Weapons (Phases) for Round");
    }
}