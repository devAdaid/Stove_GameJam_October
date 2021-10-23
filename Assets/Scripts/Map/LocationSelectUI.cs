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
        _dayText.text = $"{day}일 {(isDay ? "낮" : "밤")}";
        _statText.text = $"임시 스탯 UI {System.Environment.NewLine}"
            + $"액션: {Global.Player.Stat.GetStat(StatType.Action)} {System.Environment.NewLine}"
            + $"추리: {Global.Player.Stat.GetStat(StatType.Detective)} {System.Environment.NewLine}"
            + $"판타지: {Global.Player.Stat.GetStat(StatType.Fantasy)} {System.Environment.NewLine}"
            + $"호러: {Global.Player.Stat.GetStat(StatType.Horror)} {System.Environment.NewLine}"
            + $"무협: {Global.Player.Stat.GetStat(StatType.OrientalFantasy)} {System.Environment.NewLine}"
            + $"로맨스: {Global.Player.Stat.GetStat(StatType.Romance)} {System.Environment.NewLine}";
    }
}
