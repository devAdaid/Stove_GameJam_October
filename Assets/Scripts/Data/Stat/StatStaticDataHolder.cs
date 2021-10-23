using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatStaticDataHolder
{
    private readonly Dictionary<StatType, StatStaticDataRecord> _dataByKey;

    public StatStaticDataHolder()
    {
        var records = Resources.LoadAll<StatStaticDataRecord>("Data/Stat");
        _dataByKey = records.ToDictionary(x => x.Id, x => x);
    }

    public StatStaticDataRecord GetData(StatType stat)
    {
        if (_dataByKey.TryGetValue(stat, out var data))
        {
            return data;
        }

        return null;
    }
}