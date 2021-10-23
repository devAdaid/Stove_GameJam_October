public class Sequence_AddStat : VisualNovelSequence
{
    public override bool NeedWait => false;

    private StatValue _statValue;

    public Sequence_AddStat(IVisualNovelAPI api, StatValue statValue) : base(api)
    {
        _statValue = statValue;
    }

    public override void Execute()
    {
        _api.ApplyResultStat(_statValue);
    }
}