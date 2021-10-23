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
    /// �� ���ӿ� ���� �̺�Ʈ ����Ʈ�� �������� �ߺ����� �ʰ� �����Ѵ�. (�� 8��)
    /// </summary>
    public List<EventStaticDataRecord> GetRandomList()
    {
        var result = new List<EventStaticDataRecord>();

        // 1���� - 2��
        var day1 = GetDataListByDayRange(DayRangeType.Day1);
        day1 = RandomEx.Shuffle(day1);
        for (int i = 0; i < 2; i++)
        {
            result.Add(day1[i]);
        }

        // 2~3���� - 4��
        var day2to3 = GetDataListByDayRange(DayRangeType.Day2to3);
        day2to3 = RandomEx.Shuffle(day2to3);
        for (int i = 0; i < 4; i++)
        {
            result.Add(day2to3[i]);
        }

        // 4���� - 2��
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
