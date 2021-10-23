using AY.Core;

public class GlobalHolder : Singleton<GlobalHolder>
{
    public readonly EventStaticDataHolder Events;

    public GlobalHolder()
    {
        Events = new EventStaticDataHolder();
    }
}