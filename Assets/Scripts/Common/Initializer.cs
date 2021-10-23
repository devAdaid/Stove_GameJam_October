public class Initializer : MonoSingleton<Initializer>
{
    private void Awake()
    {
        GlobalHolder.Instance.EchoForCreate();
        Global.Player.Reset();
    }

    private void Start()
    {
        PlayIntro();
    }

    private void PlayIntro()
    {
        var introContext = new VisualNovelIntroContext(Global.API, Global.UI);
    }
}