using System;
using System.Collections.Generic;
using System.Linq;

public static class RandomEx
{
    public static List<T> Shuffle<T>(List<T> list)
    {
        var random = new Random();
        var result = list.OrderBy(x => random.Next()).ToList();
        return result;
    }
}