using System;
using System.Collections.Generic;
using UnityEngine;

public enum VisualNovelSequenceGroupType
{
    Invalid = 0,
    Location,
    EventStart,
    EventOption,
    EventEnd,
}

public class VisualNovelContext
{
    private readonly List<IVisualNovelSequence> _locationSequence;
    private readonly List<IVisualNovelSequence> _eventStartSequence;

    private readonly StatValue _option1StandardStatValue;
    private readonly List<IVisualNovelSequence> _option1SuccessSequece;
    private readonly List<IVisualNovelSequence> _option1FailSequece;

    private readonly StatValue _option2StandardStatValue;
    private readonly List<IVisualNovelSequence> _option2SuccessSequece;
    private readonly List<IVisualNovelSequence> _option2FailSequece;

    private readonly List<IVisualNovelSequence> _eventEndSequence;

    private readonly VisualNovelAPI _api;
    private readonly Action _onEnd;

    private VisualNovelSequenceGroupType _currentSequenceGroup;
    private List<IVisualNovelSequence> _currentSequence;
    private int _currentSequenceIndex;

    public VisualNovelContext(VisualNovelAPI api, VisualNovelUIControl uiControl, LocationStaticDataRecord locationData, EventStaticDataRecord eventData, int standardStatValue, Action onEnd)
    {
        _api = api;
        _api.SetContext(this);
        _onEnd = onEnd;

        _api.SetInputBlockerEnable(true);
        _api.HideLocationSelectUI();

        _locationSequence = new List<IVisualNovelSequence>();
        _eventStartSequence = new List<IVisualNovelSequence>();
        _option1SuccessSequece = new List<IVisualNovelSequence>();
        _option1FailSequece = new List<IVisualNovelSequence>();
        _option2SuccessSequece = new List<IVisualNovelSequence>();
        _option2FailSequece = new List<IVisualNovelSequence>();
        _eventEndSequence = new List<IVisualNovelSequence>();

        _option1StandardStatValue = new StatValue(eventData.Option1.StandardStatType, standardStatValue);
        _option2StandardStatValue = new StatValue(eventData.Option2.StandardStatType, standardStatValue);

        MakeLocationSequences(locationData);
        MakeEventSequences(eventData);
        MakeOptionSequence(eventData.Option1, eventData.NPC, _option1SuccessSequece, _option1FailSequece);
        MakeOptionSequence(eventData.Option2, eventData.NPC, _option2SuccessSequece, _option2FailSequece);

        _currentSequenceGroup = VisualNovelSequenceGroupType.Location;
        _currentSequence = _locationSequence;
        _currentSequenceIndex = 0;

        ExecuteUntilWatingSequence();
    }

    public void AdvanceSequence()
    {
        ExecuteUntilWatingSequence();
    }

    public bool CanSelectOption()
    {
        return _currentSequenceGroup == VisualNovelSequenceGroupType.EventStart;
    }

    public void SelectOption(int option)
    {
        if (!CanSelectOption())
        {
            return;
        }

        int currentStat;
        switch (option)
        {
            case 1:
                currentStat = _api.GetCurrentStatValue(_option1StandardStatValue.StatType);
                if (currentStat >= _option1StandardStatValue.Value)
                {
                    _currentSequenceGroup = VisualNovelSequenceGroupType.EventOption;
                    _currentSequence = _option1SuccessSequece;
                    _currentSequenceIndex = 0;
                }
                else
                {
                    _currentSequenceGroup = VisualNovelSequenceGroupType.EventOption;
                    _currentSequence = _option1FailSequece;
                    _currentSequenceIndex = 0;
                }
                break;
            case 2:
                currentStat = _api.GetCurrentStatValue(_option2StandardStatValue.StatType);
                if (currentStat >= _option2StandardStatValue.Value)
                {
                    _currentSequenceGroup = VisualNovelSequenceGroupType.EventOption;
                    _currentSequence = _option2SuccessSequece;
                    _currentSequenceIndex = 0;
                }
                else
                {
                    _currentSequenceGroup = VisualNovelSequenceGroupType.EventOption;
                    _currentSequence = _option2FailSequece;
                    _currentSequenceIndex = 0;
                }
                break;
        }

        ExecuteUntilWatingSequence();
    }

    private void MakeLocationSequences(LocationStaticDataRecord locationData)
    {
        _locationSequence.Add(new Sequence_ChangeBackground(_api, locationData.Id));

        foreach (var text in locationData.MonologueText)
        {
            _locationSequence.Add(new Sequence_MonologueText(_api, text));
        }

        var statValue = new StatValue(locationData.StatType, 1);
        _locationSequence.Add(new Sequence_AddStat(_api, statValue));

        var statString = Global.KRStrings.GetStatChangeString(statValue);
        _locationSequence.Add(new Sequence_MonologueText(_api, statString));
    }

    private void MakeEventSequences(EventStaticDataRecord eventData)
    {
        // Event Start Sequence
        _eventStartSequence.Add(new Sequence_ChangeNPCStanding(_api, eventData.NPC, EmotionType.Idle));
        foreach (var text in eventData.DialogueTexts)
        {
            _eventStartSequence.Add(new Sequence_NPCDialogueText(_api, eventData.NPC, text));
        }
        _eventStartSequence.Add(new Sequence_ShowOption(_api, eventData.Option1.OptionText, eventData.Option2.OptionText));

        // Event End Sequence
        // TODO
        //_locationSequence.Add(new Sequence_ChangeBackground(api, LocationType.Map));
    }

    private void MakeOptionSequence(EventStaticDataRecordOption optionData, NPCType npc, List<IVisualNovelSequence> successList, List<IVisualNovelSequence> failList)
    {
        // Success
        successList.Add(new Sequence_ChangeNPCStanding(_api, npc, EmotionType.Positive));
        successList.Add(new Sequence_NPCDialogueText(_api, npc, optionData.SucessReactionText));
        successList.Add(new Sequence_AddStat(_api, optionData.SuccessResultStatValue));
        var statString = Global.KRStrings.GetStatChangeString(optionData.SuccessResultStatValue);
        successList.Add(new Sequence_MonologueText(_api, statString));

        // Fail
        failList.Add(new Sequence_ChangeNPCStanding(_api, npc, EmotionType.Negative));
        failList.Add(new Sequence_NPCDialogueText(_api, npc, optionData.FailReactionText));
        failList.Add(new Sequence_AddStat(_api, optionData.FailResultStatValue));
        statString = Global.KRStrings.GetStatChangeString(optionData.FailResultStatValue);
        failList.Add(new Sequence_MonologueText(_api, statString));
    }

    private void ExecuteUntilWatingSequence()
    {
        bool needWait = false;
        while (!needWait)
        {
            if (_currentSequenceIndex < _currentSequence.Count)
            {
                var sequnce = _currentSequence[_currentSequenceIndex];
                sequnce.Execute();
                needWait = sequnce.NeedWait;
                Debug.Log($"{_currentSequenceGroup}, {_currentSequenceIndex}");
                _currentSequenceIndex += 1;
            }
            else
            {
                if (!SelectNextSequence())
                {
                    break;
                }
            }
        }
    }

    private bool SelectNextSequence()
    {
        switch (_currentSequenceGroup)
        {
            case VisualNovelSequenceGroupType.Location:
                _currentSequenceGroup = VisualNovelSequenceGroupType.EventStart;
                _currentSequence = _eventStartSequence;
                _currentSequenceIndex = 0;
                return true;
            case VisualNovelSequenceGroupType.EventStart:
                return false;
            case VisualNovelSequenceGroupType.EventOption:
                _currentSequenceGroup = VisualNovelSequenceGroupType.EventEnd;
                _currentSequence = _eventEndSequence;
                _currentSequenceIndex = 0;
                return true;
            case VisualNovelSequenceGroupType.EventEnd:
                OnEnd();
                return false;
        }
        return false;
    }

    private void OnEnd()
    {
        var mapSprite = Global.Locations.GetData(LocationType.Map).BackgroundSprite;
        _api.SetBackground(mapSprite);
        _api.HideNPCStanding();
        _api.HideTextWindow();

        _api.SetInputBlockerEnable(false);
        _api.ShowLocationSelectUI();
        _api.UpdateLocationSelectUI();

        _onEnd?.Invoke();
    }
}
