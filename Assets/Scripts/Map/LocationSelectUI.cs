using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocationSelectUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _dayText;
    [SerializeField]
    private Image _icon;
    [SerializeField]
    private Sprite _sunIcon;
    [SerializeField]
    private Sprite _moonIcon;
    [SerializeField]
    private List<StatEntry> _statEntries;

    private static readonly StatType[] STATS = new StatType[]
    {
        StatType.Action,
        StatType.Horror,
        StatType.Detective,
        StatType.Romance,
        StatType.OrientalFantasy,
        StatType.Fantasy,
    };

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        var currentTurn = Global.Player.CurrentTurn;
        var day = (currentTurn / 2) + 1;
        var isDayTime = (currentTurn % 2) == 0;
        var dayString = string.Format(Global.KRStrings.GetString(KRStringHolder.DAY_FORMAT), day);
        _dayText.text = dayString;
        _icon.sprite = isDayTime ? _sunIcon : _moonIcon;

        for (int i = 0; i < 6; i++)
        {
            var data = Global.Stats.GetData(STATS[i]);
            var value = Global.Player.Stat.GetStat(STATS[i]);
            _statEntries[i].SetEntry(data.IconSprite, data.DisplayName, value);
        }
    }
}
