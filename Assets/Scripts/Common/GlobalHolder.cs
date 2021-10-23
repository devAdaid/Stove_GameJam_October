public class GlobalHolder : Singleton<GlobalHolder>
{
    public readonly EventStaticDataHolder Events;
    public readonly NPCStaticDataHolder NPCs;
    public readonly LocationStaticDataHolder Locations;

    public GlobalHolder()
    {
        Events = new EventStaticDataHolder();
        NPCs = new NPCStaticDataHolder();
        Locations = new LocationStaticDataHolder();
    }
}