public abstract class VisualNovelSequence : IVisualNovelSequence
{
    public abstract void Execute();

    protected IVisualNovelAPI _api;

    public VisualNovelSequence(IVisualNovelAPI api)
    {
        _api = api;
    }
}