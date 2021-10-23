using System;
using System.Collections.Generic;

public class VisualNovelIntroContext : IVisualNovelContext
{
    private readonly List<IVisualNovelSequence> _sequence;
    private int _currentSequenceIndex;
    private readonly VisualNovelAPI _api;
    private readonly Action _onEnd;

    public VisualNovelIntroContext(VisualNovelAPI api, VisualNovelUIControl uiControl)
    {
        _api = api;
        _api.SetContext(this);

        _sequence = new List<IVisualNovelSequence>();

        var texts = Global.KRStrings.GetIntroStrings();
        foreach (var text in texts)
        {
            _sequence.Add(new Sequence_MonologueText(_api, text));
        }

        _api.SetInputBlockerEnable(true);

        ExecuteUntilWatingSequence();
    }

    public void AdvanceSequence()
    {
        ExecuteUntilWatingSequence();
    }

    private void ExecuteUntilWatingSequence()
    {
        bool needWait = false;
        while (!needWait)
        {
            if (_currentSequenceIndex < _sequence.Count)
            {
                var sequnce = _sequence[_currentSequenceIndex];
                sequnce.Execute();
                needWait = sequnce.NeedWait;
                _currentSequenceIndex += 1;
            }
            else
            {
                OnEnd();
                break;
            }
        }
    }

    private void OnEnd()
    {
        var mapSprite = Global.Locations.GetData(LocationType.Map).BackgroundSprite;
        _api.ShowBackground();
        _api.SetBackground(mapSprite);
        _api.HideTextWindow();

        _api.SetInputBlockerEnable(false);
        _api.ShowLocationSelectUI();
        _api.UpdateLocationSelectUI();

        _onEnd?.Invoke();
    }

    public bool CanSelectOption()
    {
        return false;
    }

    public void SelectOption(int option) { }
}