using System.Collections.Generic;
using strange.extensions.signal.impl;
using UnityEngine;


// Exit Popup

/// <summary>
/// Intention to show a pop-up of Exit
/// <remarks>UI Button</remarks>
/// </summary>
public class RoundShowExitSignal : Signal<GameObject> {}
/// <summary>
/// Intention to leave (exit) the round
/// <remarks>UI Button</remarks>
/// </summary>
public class RoundExitConfirmedSignal : Signal {}
/// <summary>
/// Intention to return back to round
/// <remarks>UI Button</remarks>
/// </summary>
public class RoundExitCanceledSignal : Signal{}

// Start
public class RoundLoadedSignal : Signal {} 

// Round Phase
public class RoundGetPhaseSignal : Signal {}
public class RoundPhaseLoadedSignal : Signal<IWeapon, Dictionary<int, IWeapon>, RoundStatsData> {}
/// <summary>
/// Signal of answer action of "int" choice
/// <remarks>UI Button</remarks>
/// </summary>
public class RoundAnsweredSignal : Signal<int> {}

/// <summary>
/// Sending the information that the correct variant was chosen in the phase
/// </summary>
public class RoundCorrectSignal : Signal {}

// Round End
public class RoundEndSignal : Signal {}
public class RoundLostSignal : Signal<IWeapon> {}
public class RoundWonSignal : Signal {}

/// <summary>
/// Intention to return to Main Menu
/// <remarks>UI Button</remarks>
/// </summary>
public class RoundToMenuSignal : Signal {}

/// <summary>
/// Intention to go to Next Round after Win
/// <remarks>UI Button</remarks>
/// </summary>
public class RoundToNextSignal : Signal {}

/// <summary>
/// Intention to re-play round
/// <remarks>UI Button</remarks>
/// </summary>
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