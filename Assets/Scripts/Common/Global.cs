public static class Global
{
    public static EventStaticDataHolder Events => GlobalHolder.Instance.Events;
    public static NPCStaticDataHolder NPCs => GlobalHolder.Instance.NPCs;
    public static LocationStaticDataHolder Locations => GlobalHolder.Instance.Locations;
}