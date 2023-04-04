
using System.Collections.Generic;

public interface IRound
{
    public bool IsPlaying { get; }
    public Queue<IWeapon> Weapons { get; }
    public IWeapon Card { get; }
    public short RoundNumber { get; set; }


    public void SetWeapons(List<IWeapon> list);
    
}
