using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LocationStaticDataHolder
{
    private readonly Dictionary<LocationType, LocationStaticDataRecord> _dataByKey;

    public LocationStaticDataHolder()
    {
        var records = Resources.LoadAll<LocationStaticDataRecord>("Data/Location");
        _dataByKey = records.ToDictionary(x => x.Id, x => x);
    }

    public LocationStaticDataRecord GetData(LocationType location)
    {
        if (_dataByKey.TryGetValue(location, out var data))
        {
            return data;
        }

        return null;
    }
}