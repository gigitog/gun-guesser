using strange.extensions.signal.impl;

public class MenuLoadSignal : Signal {}

/// <summary>
/// Dispatched by <see cref="MenuLoadCommand"/> after some processing
/// </summary>
public class MenuLoadedSignal : Signal {}

/// <summary>
/// Click on card of <see cref="MenuCardView"/>, namely <see cref="IWeapon"/> in Main Menu 
/// <remarks>UI Button</remarks>
/// </summary>
public class MenuCardClickedSignal : Signal {}

/// <summary>
/// Dispatched by <see cref="MenuCardChangeCommand"/> after getting random card <see cref="IWeapon"/>
/// </summary>
public class MenuCardChangedSignal : Signal<IWeapon> {}

/// <summary>
/// Intention of loading <see cref="IRound"/>
/// <remarks>UI Button</remarks>
/// </summary>
public class MenuStartRoundSignal : Signal {}

/// <summary>
/// Intention to open Profile Interface
/// <remarks>UI Button</remarks>
/// </summary>
public class MenuProfileLoadSignal : Signal {}

/// <summary>
/// Intention to open user Inventory Interface
/// <remarks>UI Button</remarks>
/// </summary>
public class MenuInventoryLoadSignal : Signal {}

/// <summary>
/// Dispatched by <see cref="InventoryLoadCommand"/> after some processing
/// </summary>
public class InventoryLoadedSignal : Signal {}

/// <summary>
/// Intention to open full information about certain <see cref="IInventoryElement"/>, namely <see cref="IWeapon"/>
/// <remarks>UI Button</remarks>
/// </summary>
public class InventoryElementClickedSignal : Signal<IInventoryElement> {}

/// <summary>
/// Dispatched by <see cref="ProfileLoadCommand"/> after some processing
/// </summary>
public class ProfileLoadedSignal : Signal {}

public class ProfileToMenuSignal : Signal {}
public class InventoryToMenuSignal : Signal {}
