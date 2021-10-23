using System;

public struct StatValue : IComparable<StatValue>
{
    public StatType StatType;
    public int Value;

    public StatValue(StatType statType, int value)
    {
        StatType = statType;
        Value = value;
    }

    public int CompareTo(StatValue other)
    {
        return Value.CompareTo(other.Value);
    }
}