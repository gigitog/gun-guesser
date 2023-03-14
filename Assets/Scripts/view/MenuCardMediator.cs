using strange.extensions.mediation.impl;
using UnityEditor;


public class MenuCardMediator : Mediator
{
    [Inject] 
    public MenuCardView view { get; set; }
    
    [Inject]
    public MenuCardChangedSignal menuCardChangedSignal{ get; set;}

    [Inject]
    public IGameConfig config { get; set; }
    
    public override void OnRegister()
    {
        menuCardChangedSignal.AddListener(SetCard);
    }

    private void SetCard(IWeapon weapon)
    {
        view.Name = weapon.Name;
        view.Classification = config.GetTextClassification(weapon.WeaponClass);
        view.Type = config.GetTextType(weapon.Type);
        view.Side = weapon.Side.ToString();
    }

    public override void OnRemove()
    {
        menuCardChangedSignal.RemoveListener(SetCard);
    }
}
