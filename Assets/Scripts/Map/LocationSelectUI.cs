using TMPro;
using UnityEngine;

public class LocationSelectUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _dayText;
    [SerializeField]
    private TMP_Text _statText;

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        var currentTurn = Global.Player.CurrentTurn;
        var day = (currentTurn / 2) + 1;
        var isDay = (currentTurn % 2) == 0;
        var dayString = string.Format(Global.KRStrings.GetString(KRStringHolder.DAY_FORMAT), day);
        _dayText.text = $"{dayString} {(isDay ? Global.KRStrings.GetString(KRStringHolder.DAY_TIME) : Global.KRStrings.GetString(KRStringHolder.NIGHT))}";
        _statText.text = $"[Temp] Stat UI {System.Environment.NewLine}"
            + $"{Global.KRStrings.GetString(StatType.Action)}: {Global.Player.Stat.GetStat(StatType.Action)} {System.Environment.NewLine}"
            + $"{Global.KRStrings.GetString(StatType.Horror)}: {Global.Player.Stat.GetStat(StatType.Horror)} {System.Environment.NewLine}"
            + $"{Global.KRStrings.GetString(StatType.Detective)}: {Global.Player.Stat.GetStat(StatType.Detective)} {System.Environment.NewLine}"
            + $"{Global.KRStrings.GetString(StatType.Romance)}: {Global.Player.Stat.GetStat(StatType.Romance)} {System.Environment.NewLine}"
            + $"{Global.KRStrings.GetString(StatType.OrientalFantasy)}: {Global.Player.Stat.GetStat(StatType.OrientalFantasy)} {System.Environment.NewLine}"
            + $"{Global.KRStrings.GetString(StatType.Fantasy)}: {Global.Player.Stat.GetStat(StatType.Fantasy)} {System.Environment.NewLine}";
    }
}
