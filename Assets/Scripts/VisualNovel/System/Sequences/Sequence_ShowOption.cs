public class Sequence_ShowOption : VisualNovelSequence
{
    public override bool NeedWait => true;

    private string _option1Text;
    private string _option2Text;

    public Sequence_ShowOption(IVisualNovelAPI api, string option1Text, string option2Text) : base(api)
    {
        _option1Text = option1Text;
        _option2Text = option2Text;
    }

    public override void Execute()
    {
        _api.ShowOptions(_option1Text, _option2Text);
    }
}