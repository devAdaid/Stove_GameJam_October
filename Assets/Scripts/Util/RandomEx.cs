using System;
using System.Collections.Generic;
using System.Linq;

public static class RandomEx
{
    public static void Shuffle<T>(List<T> list)
    {
        var random = new Random();
        list = list.OrderBy(x => random.Next()).ToList();
    }
}