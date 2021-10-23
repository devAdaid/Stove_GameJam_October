public class Sequence_ChangeBackground : VisualNovelSequence
{
    public Sequence_ChangeBackground(IVisualNovelAPI api) : base(api)
    {
    }

    public override void Execute()
    {
        _api.ChangeBackground(null);
    }
}