using System.Collections.Generic;

public class PlayerStat
{
    public readonly Dictionary<StatType, int> _stats;

    public PlayerStat()
    {
        _stats = new Dictionary<StatType, int>();
        _stats.Add(StatType.Action, 0);
        _stats.Add(StatType.Detective, 0);
        _stats.Add(StatType.Fantasy, 0);
        _stats.Add(StatType.Romance, 0);
        _stats.Add(StatType.OrientalFantasy, 0);
        _stats.Add(StatType.Horror, 0);
    }

    public int GetStat(StatType stat)
    {
        return _stats[stat];
    }

    public int AddStat(StatValue statValue)
    {
        var currentStat = _stats[statValue.StatType];
        return _stats[statValue.StatType] = currentStat + statValue.Value;
    }
}
