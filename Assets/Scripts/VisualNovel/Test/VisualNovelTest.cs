using UnityEngine;

public class VisualNovelTest : MonoBehaviour
{
    public LocationType Location;
    public string EventId;

    public VisualNovelUIControl ui;
    public VisualNovelContext context;

    void Start()
    {
        var locationData = Global.Locations.GetData(Location);
        var eventData = Global.Events.GetDataById(EventId);
        context = new VisualNovelContext(ui, locationData, eventData);
    }
}
