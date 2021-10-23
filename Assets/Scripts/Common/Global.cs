public static class Global
{
    public static VisualNovelUIControl UI => VisualNovelUIControl.Instance;
    public static VisualNovelAPI API => GlobalHolder.Instance.VisualNovelAPI;

    public static PlayerHolder Player => GlobalHolder.Instance.Player;

    public static EventStaticDataHolder Events => GlobalHolder.Instance.Events;
    public static NPCStaticDataHolder NPCs => GlobalHolder.Instance.NPCs;
    public static LocationStaticDataHolder Locations => GlobalHolder.Instance.Locations;
    public static StatStaticDataHolder Stats => GlobalHolder.Instance.Stats;
    public static KRStringHolder KRStrings => GlobalHolder.Instance.KRStrings;
}