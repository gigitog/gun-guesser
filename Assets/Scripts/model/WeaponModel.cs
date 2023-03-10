public class WeaponModel : IWeapon
{
    public string Name { get; private set; }
    public string Modification { get; private set; }
    public string Year { get; private set; }
    public string Country { get; private set; }
    // Earth, Air, Rocket, Hand Weapon
    public string Class { get; private set; }
    // MTB, Jet, AAW
    public string Type { get; private set; }
    public string Side { get; private set; }
}