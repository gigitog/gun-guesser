using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class MenuView : View
{
    
    public Signal MenuCardClickedSignal { get; set; }
    public Signal MenuInventoryClickedSignal { get; set; }
    public Signal MenuProfileClickedSignal { get; set; }
    public Signal StartClickedSignal { get; set; }
    
    public void StartClick()
    {
        
    }

    public void ProfileClick()
    {
        MenuProfileClickedSignal.Dispatch();
    }

    public void InventoryClick()
    {
        MenuInventoryClickedSignal.Dispatch();
    }

    public void CardClick()
    {
        MenuCardClickedSignal.Dispatch();
    }

    public void StartClicked()
    {
        StartClickedSignal.Dispatch();
    }
}
