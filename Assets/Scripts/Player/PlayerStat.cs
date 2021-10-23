using System.Collections.Generic;
using System.Linq;

public class PlayerStat
{
    public readonly Dictionary<StatType, int> _stats;

    public static readonly int SUM_GOOD_END = 14;

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

    public void Reset()
    {
        _stats[StatType.Action] = 0;
        _stats[StatType.Detective] = 0;
        _stats[StatType.Fantasy] = 0;
        _stats[StatType.Romance] = 0;
        _stats[StatType.OrientalFantasy] = 0;
        _stats[StatType.Horror] = 0;
    }

    public int GetStat(StatType stat)
    {
        return _stats[stat];
    }

    public int GetSum()
    {
        return _stats.Sum(x => x.Value);
    }

    public int AddStat(StatValue statValue)
    {
        var currentStat = _stats[statValue.StatType];
        return _stats[statValue.StatType] = currentStat + statValue.Value;
    }
}
