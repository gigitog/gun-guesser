using strange.extensions.signal.impl;using UnityEngine.UIElements;


// Start
public class RoundLoadedSignal : Signal<IRound> {} 

// Round Phase
public class RoundCardLoadedSignal : Signal<IWeapon, IWeapon, IWeapon> {}
public class RoundAnsweredSignal : Signal<int> {}
public class RoundCorrectAnsweredSignal : Signal<IWeapon> {}

// Round End
public class RoundLostSignal : Signal {}
public class RoundWonSignal : Signal {}

public class RoundToMenuSignal : Signal {}
public class RoundToNextSignal : Signal {}
public class RoundToAgainSignal : Signal {}

// Hearts Behaviour
public class HeartLostSignal : Signal {}
public class HeartRefilledSignal : Signal {}
