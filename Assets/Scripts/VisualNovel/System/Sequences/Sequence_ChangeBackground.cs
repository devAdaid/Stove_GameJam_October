public class Sequence_ChangeBackground : VisualNovelSequence
{
    public override bool NeedWait => false;

    private LocationType _location;

    public Sequence_ChangeBackground(IVisualNovelAPI api, LocationType location) : base(api)
    {
        _location = location;
    }

    public override void Execute()
    {
        if (_location == LocationType.Invalid)
        {
            if (_api.IsBackgroundVisible)
            {
                _api.HideBackground();
            }
        }
        else
        {
            if (!_api.IsBackgroundVisible)
            {
                _api.ShowBackground();
            }
            var locationData = Global.Locations.GetData(_location);
            _api.SetBackground(locationData.BackgroundSprite);
        }
    }
}