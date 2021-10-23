public class GlobalHolder : MonoSingleton<GlobalHolder>
{
    public VisualNovelAPI VisualNovelAPI;

    // Static Data
    public EventStaticDataHolder Events;
    public NPCStaticDataHolder NPCs;
    public LocationStaticDataHolder Locations;
    public StatStaticDataHolder Stats;
    public KRStringHolder KRStrings;

    // Player
    public PlayerHolder Player;

    void Awake()
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