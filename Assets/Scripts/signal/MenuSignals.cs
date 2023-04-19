using strange.extensions.signal.impl;


public class MenuLoadSignal : Signal {}


public class MenuLoadedSignal : Signal {}

public class MenuCardClickedSignal : Signal {}

public class MenuCardChangedSignal : Signal<IWeapon> {}

public class MenuStartRoundSignal : Signal {}