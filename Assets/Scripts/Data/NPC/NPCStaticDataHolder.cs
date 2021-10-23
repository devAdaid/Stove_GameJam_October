using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCStaticDataHolder
{
    private readonly Dictionary<NPCType, NPCStaticDataRecord> _dataByKey;

    public NPCStaticDataHolder()
    {
        var records = Resources.LoadAll<NPCStaticDataRecord>("Data/NPC");
        _dataByKey = records.ToDictionary(x => x.Id, x => x);
    }

    public NPCStaticDataRecord GetData(NPCType npc)
    {
        if (_dataByKey.TryGetValue(npc, out var data))
        {
            return data;
        }

        return null;
    }
}
