using System.Collections.Generic;
using strange.extensions.signal.impl;
using UnityEngine;


// Exit Popup
public class RoundShowExitSignal : Signal<GameObject> {}
public class RoundExitConfirmedSignal : Signal {}
public class RoundExitCanceledSignal : Signal{}

// Start
public class RoundLoadedSignal : Signal {} 

// Round Phase
public class RoundGetPhaseSignal : Signal {}
public class RoundPhaseLoadedSignal : Signal<IWeapon, Dictionary<int, IWeapon>, RoundStatsData> {}
public class RoundAnsweredSignal : Signal<int> {}

public class RoundCorrectSignal : Signal {}

// Round End
public class  RoundEndSignal : Signal {}
public class RoundLostSignal : Signal<IWeapon> {}
public class RoundWonSignal : Signal {}

public class RoundToMenuSignal : Signal {}
public class RoundToNextSignal : Signal {}
public class RoundToAgainSignal : Signal {}

// Hearts Behaviour
public class HeartLostSignal : Signal {}
public class HeartRefilledSignal : Signal {}

public class IncorrectAnswerData
{
    public IWeapon enemy;
    public IWeapon correctAnswer;
    public IWeapon incorrectAnswer;
}