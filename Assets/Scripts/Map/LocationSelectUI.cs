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
        _dayText.text = $"{day}�� {(isDay ? "��" : "��")}";
        _statText.text = $"�ӽ� ���� UI {System.Environment.NewLine}"
            + $"�׼�: {Global.Player.Stat.GetStat(StatType.Action)} {System.Environment.NewLine}"
            + $"�߸�: {Global.Player.Stat.GetStat(StatType.Detective)} {System.Environment.NewLine}"
            + $"��Ÿ��: {Global.Player.Stat.GetStat(StatType.Fantasy)} {System.Environment.NewLine}"
            + $"ȣ��: {Global.Player.Stat.GetStat(StatType.Horror)} {System.Environment.NewLine}"
            + $"����: {Global.Player.Stat.GetStat(StatType.OrientalFantasy)} {System.Environment.NewLine}"
            + $"�θǽ�: {Global.Player.Stat.GetStat(StatType.Romance)} {System.Environment.NewLine}";
    }
}
