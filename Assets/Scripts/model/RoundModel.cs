using System.Collections.Generic;

public class RoundModel : IRound
{
    public Queue<IWeapon> Weapons { get; }
    
    [Inject]
    public IWeapon Card { get; }

    public short RoundNumber { get; set; }
}