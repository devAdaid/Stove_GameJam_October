public class NPCGlobal : MonoSingleton<NPCGlobal>
{
    public NPCStaticDataHolder NPCs;
    public KRStringHolder KRStrings;

    private void Awake()
    {
        NPCs = new NPCStaticDataHolder();
        KRStrings = new KRStringHolder();
    }
}