using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class VisualNovelGoodEndContext : IVisualNovelContext
{
    private readonly List<IVisualNovelSequence> _sequence;
    private int _currentSequenceIndex;
    private readonly VisualNovelAPI _api;

    public VisualNovelGoodEndContext(VisualNovelAPI api, VisualNovelUIControl uiControl)
    {
        _api = api;
        _api.SetContext(this);

        _sequence = new List<IVisualNovelSequence>();

        _api.HideLocationSelectUI();

        var bgSprite = Global.Locations.GetData(LocationType.GoodEnd).BackgroundSprite;
        _api.SetBackground(bgSprite);

        var texts = Global.KRStrings.GetGoodEndStrings();
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
        SceneManager.LoadScene("3_End");
    }

    public bool CanSelectOption()
    {
        return false;
    }

    public void SelectOption(int option) { }
}