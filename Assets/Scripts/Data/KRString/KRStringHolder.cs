using System.Collections.Generic;

public class KRStringHolder
{
    private Dictionary<string, string> _stringPair;

    #region Key
    public static readonly string DAY_FORMAT = "DayFormat";
    public static readonly string DAY_TIME = "DayTime";
    public static readonly string NIGHT = "Night";
    public static readonly string STAT_UP_FORMAT = "StatUpFormat";
    public static readonly string STAT_DOWN_FORMAT = "StatDownFormat";
    #endregion

    public KRStringHolder()
    {
        _stringPair = new Dictionary<string, string>();
        var csvParsed = CSVParser.ReadFromFile("Data/KRString/Data_KRString");
        foreach (var pair in csvParsed)
        {
            var key = (string)pair["Key"];
            var str = (string)pair["String"];
            _stringPair.Add(key, str);
        }
    }

    public string GetString(string key)
    {
        if (_stringPair.TryGetValue(key, out var val))
        {
            return val;
        }
        return string.Empty;
    }

    public string GetStatChangeString(StatValue statValue)
    {
        var statData = Global.Stats.GetData(statValue.StatType);
        if (statValue.Value > 0)
        {
            return string.Format(GetString(STAT_UP_FORMAT), statData.DisplayName);
        }

        return string.Format(GetString(STAT_DOWN_FORMAT), statData.DisplayName);
    }

    public List<string> GetIntroStrings()
    {
        var result = new List<string>();
        result.Add(GetString("Intro_1"));
        result.Add(GetString("Intro_2"));
        result.Add(GetString("Intro_3"));
        result.Add(GetString("Intro_4"));
        result.Add(GetString("Intro_5"));
        return result;
    }

    public List<string> GetGoodEndStrings()
    {
        var result = new List<string>();
        result.Add(GetString("GoodEnd_1"));
        result.Add(GetString("GoodEnd_2"));
        result.Add(GetString("GoodEnd_3"));
        result.Add(GetString("GoodEnd_4"));
        result.Add(GetString("GoodEnd_5"));
        return result;
    }

    public List<string> GetBadEndStrings()
    {
        var result = new List<string>();
        result.Add(GetString("BadEnd_1"));
        result.Add(GetString("BadEnd_2"));
        result.Add(GetString("BadEnd_3"));
        result.Add(GetString("BadEnd_4"));
        result.Add(GetString("BadEnd_5"));
        return result;
    }
}
