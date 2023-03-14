using strange.extensions.context.impl;


public class Root : ContextView
{

    void Awake()
    {
        context = new GunGuesserMainContext(this);
    }
}
