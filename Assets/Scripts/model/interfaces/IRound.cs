
using System.Collections.Generic;

public interface IRound
{
    public Queue<IWeapon> Weapons { get; }
    public IWeapon Card { get; }
    public short RoundNumber { get; set; }
}
