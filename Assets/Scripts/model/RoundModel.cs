using System.Collections.Generic;

public class RoundModel : IRound
{
    public List<IWeapon> Weapons { get; }
    [Inject]
    public IWeapon Card { get; }
}