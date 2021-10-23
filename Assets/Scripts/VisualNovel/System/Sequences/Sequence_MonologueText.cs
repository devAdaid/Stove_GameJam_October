public class Sequence_MonologueText : VisualNovelSequence
{
    public override bool NeedWait => true;

    private string _monologueText;

    public Sequence_MonologueText(IVisualNovelAPI api, string monologueText) : base(api)
    {
        _monologueText = monologueText;
    }

    public override void Execute()
    {
        if (!_api.IsTextWindowVisible)
        {
            _api.ShowTextWindow();
        }

        if (_api.IsNamePlateVisible)
        {
            _api.HideNamePlate();
        }

        _api.TypeText(_monologueText);
    }
}