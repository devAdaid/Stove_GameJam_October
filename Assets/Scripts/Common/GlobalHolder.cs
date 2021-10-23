using UnityEngine;

public class GlobalHolder : Singleton<GlobalHolder>
{
    public readonly VisualNovelUIControl UI;
    public readonly VisualNovelAPI VisualNovelAPI;

    // Static Data
    public readonly EventStaticDataHolder Events;
    public readonly NPCStaticDataHolder NPCs;
    public readonly LocationStaticDataHolder Locations;
    public readonly KRStringHolder KRStrings;

    // Player
    public readonly PlayerHolder Player;

    public GlobalHolder()
    {
        UI = GameObject.FindObjectOfType<VisualNovelUIControl>();
        VisualNovelAPI = new VisualNovelAPI(UI, null);

        Events = new EventStaticDataHolder();
        NPCs = new NPCStaticDataHolder();
        Locations = new LocationStaticDataHolder();
        KRStrings = new KRStringHolder();

        var events = Events.GetRandomList();
        Player = new PlayerHolder(events);
    }
}