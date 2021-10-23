public class Initializer : MonoSingleton<Initializer>
{
    private void Awake()
    {
        GlobalHolder.Instance.EchoForCreate();
        Global.Player.Reset();
    }
}