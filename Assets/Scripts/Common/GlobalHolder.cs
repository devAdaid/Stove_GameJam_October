public class GlobalHolder : Singleton<GlobalHolder>
{
    public readonly VisualNovelAPI VisualNovelAPI;

    // Static Data
    public readonly EventStaticDataHolder Events;
    public readonly NPCStaticDataHolder NPCs;
    public readonly LocationStaticDataHolder Locations;
    public readonly StatStaticDataHolder Stats;
    public readonly KRStringHolder KRStrings;

    // Player
    public readonly PlayerHolder Player;

    public GlobalHolder()
    {
        VisualNovelAPI = new VisualNovelAPI(null);

        Events = new EventStaticDataHolder();
        NPCs = new NPCStaticDataHolder();
        Locations = new LocationStaticDataHolder();
        Stats = new StatStaticDataHolder();
        KRStrings = new KRStringHolder();

        var events = Events.GetRandomList();
        Player = new PlayerHolder(events);
    }
}