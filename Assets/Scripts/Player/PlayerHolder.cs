using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerHolder
{
    public int CurrentTurn { get; private set; }
    public readonly PlayerStat Stat;

    private readonly List<EventStaticDataRecord> _events;
    private bool _isNovelPlaying;

    private static readonly int MAX_TURN_COUNT = 8;

    public PlayerHolder(List<EventStaticDataRecord> events)
    {
        CurrentTurn = 0;
        Stat = new PlayerStat();

        _events = events;
    }

    public void VisitLocation(LocationType location)
    {
        if (_isNovelPlaying)
        {
            return;
        }

        var locationData = Global.Locations.GetData(location);
        var eventData = _events[CurrentTurn];
        var standardStatValue = GetStandardStatValue(CurrentTurn);
        var context = new VisualNovelContext(Global.API, Global.UI, locationData, eventData, standardStatValue, OnVisitEnd);
        _isNovelPlaying = true;
    }

    private void OnVisitEnd()
    {
        _isNovelPlaying = false;

        // 다음 턴으로
        CurrentTurn += 1;

        if (CurrentTurn >= MAX_TURN_COUNT)
        {
            OnGameEnd();
        }
        else
        {
            Global.UI.LocationSelectUI.UpdateUI();
        }
    }

    private void OnGameEnd()
    {
        SceneManager.LoadScene("3_End");
    }

    private static int GetStandardStatValue(int turn)
    {
        if (turn < 2)
        {
            return 0;
        }
        else if (turn < 6)
        {
            return 1;
        }

        return 2;
    }
}
