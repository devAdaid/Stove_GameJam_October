using System.Collections.Generic;

public class KRStringHolder
{
    private Dictionary<string, string> _stringPair;

    #region Key
    public static readonly string DAY_FORMAT = "DayFormat";
    public static readonly string DAY_TIME = "DayTime";
    public static readonly string NIGHT = "Night";
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

    public string GetString(StatType statType)
    {
        if (_stringPair.TryGetValue(statType.ToString(), out var val))
        {
            return val;
        }
        return string.Empty;
    }
}
