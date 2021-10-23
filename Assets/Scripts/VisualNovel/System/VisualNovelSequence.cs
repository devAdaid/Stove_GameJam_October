public abstract class VisualNovelSequence : IVisualNovelSequence
{
    public abstract bool NeedWait { get; }
    public abstract void Execute();

    protected readonly IVisualNovelAPI _api;

    public VisualNovelSequence(IVisualNovelAPI api)
    {
        _api = api;
    }

    protected void ShowNPCStandingIfNotVisible()
    {
        if (_api.IsNPCStandingVisible)
        {
            _api.ShowNPCStanding();
        }
    }

    protected void HideNPCStandingIfVisible()
    {
        if (_api.IsNPCStandingVisible)
        {
            _api.ShowNPCStanding();
        }
    }
}