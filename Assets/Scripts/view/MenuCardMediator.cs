using System;
using System.Runtime.InteropServices;
using strange.extensions.mediation.impl;
using UnityEditor;
using UnityEngine;


public class MenuCardMediator : Mediator
{
    [Inject] 
    public MenuCardView view { get; set; }
    
    [Inject]
    public MenuCardClickedSignal menuCardClickedSignal{ get; set;}
    
    [Inject]
    public MenuCardChangedSignal menuCardChangedSignal { get; set; }

    [Inject]
    public IGameConfig config { get; set; }
    
    public override void OnRegister()
    {
        view.CardClickedSignal.AddListener(CardClicked);
        
        menuCardChangedSignal.AddListener(SetCard);
        
        CardClicked();
    }

    public override void OnRemove()
    {
        // Debug.LogWarning("Mediator Remove");
        view.CardClickedSignal.RemoveListener(CardClicked);
        
        menuCardChangedSignal.RemoveListener(SetCard);
    }

    private void CardClicked()
    {
        menuCardClickedSignal.Dispatch();
    }

    private void SetCard(IWeapon weapon)
    {
        view.Name = weapon.Name;
        view.Classification = config.GetTextClassification(weapon.WeaponClass);
        view.Type = config.GetTextTypeLong(weapon.Type);
        view.Side = weapon.Side.ToString();
    }
}
