using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class VisualNovelBadEndContext : IVisualNovelContext
{
    private readonly List<IVisualNovelSequence> _sequence;
    private int _currentSequenceIndex;
    private readonly VisualNovelAPI _api;

    public VisualNovelBadEndContext(VisualNovelAPI api, VisualNovelUIControl uiControl)
    {
        _api = api;
        _api.SetContext(this);

        _sequence = new List<IVisualNovelSequence>();

        _api.HideLocationSelectUI();

        _api.HideBackground();

        var texts = Global.KRStrings.GetBadEndStrings();
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
        var count = 1;
        bool needWait = false;
        while (!needWait)
        {
            if (_currentSequenceIndex < _sequence.Count)
            {
                var sequnce = _sequence[_currentSequenceIndex];
                sequnce.Execute();
                needWait = sequnce.NeedWait;
                _currentSequenceIndex += 1;
                count += 1;
            }
            else
            {
                OnEnd();
                break;
            }
        }

        if (count > 0)
        {
            SoundManager.Instance.PlaySfx("Advance");
        }
    }

    private void OnEnd()
    {
        SceneManager.LoadScene("1_Title");
    }

    public bool CanSelectOption()
    {
        return false;
    }

    public void SelectOption(int option) { }
}