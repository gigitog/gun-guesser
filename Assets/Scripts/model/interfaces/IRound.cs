
using System.Collections.Generic;

public interface IRound
{
    public List<IWeapon> Weapons { get; }
    public IWeapon Card { get; }
}
