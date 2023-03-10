using System;
using strange.examples.signals;
using UnityEngine;
using strange.extensions.context.impl;


public class Root : ContextView
{

    void Awake()
    {
        context = new GunGuesserMainContext(this);
    }
}
