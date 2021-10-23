using System.Collections.Generic;
using System.Linq;

public class EventStaticDataHolder
{
    private readonly Dictionary<string, EventStaticDataRecord> _dataByKey;
    private readonly List<EventStaticDataRecord> _dataList;

    public EventStaticDataHolder()
    {
        _dataList = EventStaticDataParser.GetParsed();
        _dataByKey = _dataList.ToDictionary(x => x.Id, x => x);
    }

    /// <summary>
    /// 한 게임에 사용될 이벤트 리스트를 랜덤으로 중복되지 않게 구성한다. (총 8개)
    /// </summary>
    public List<EventStaticDataRecord> GetRandomList()
    {
        var result = new List<EventStaticDataRecord>();

        // 1일차 - 2개
        var day1 = GetDataListByDayRange(DayRangeType.Day1);
        day1 = RandomEx.Shuffle(day1);
        for (int i = 0; i < 2; i++)
        {
            result.Add(day1[i]);
        }

        // 2~3일차 - 4개
        var day2to3 = GetDataListByDayRange(DayRangeType.Day2to3);
        day2to3 = RandomEx.Shuffle(day2to3);
        for (int i = 0; i < 4; i++)
        {
            result.Add(day2to3[i]);
        }

        // 4일차 - 2개
        var day4 = GetDataListByDayRange(DayRangeType.Day4);
        day4 = RandomEx.Shuffle(day4);
        for (int i = 0; i < 2; i++)
        {
            result.Add(day4[i]);
        }

        return result;
    }

    public EventStaticDataRecord GetDataById(string id)
    {
        if (_dataByKey.TryGetValue(id, out var data))
        {
            return data;
        }

        return null;
    }

    public List<EventStaticDataRecord> GetDataListByDayRange(DayRangeType dayRange)
    {
        return _dataList.Where(x => x.DayRange.Equals(dayRange)).ToList();
    }
}
