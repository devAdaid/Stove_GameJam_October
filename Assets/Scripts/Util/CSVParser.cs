using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

// 출처: https://bravenewmethod.com/2014/09/13/lightweight-csv-reader-for-unity/
public static class CSVParser
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char[] TRIM_CHARS = { '\"' };

    /// <summary>
    /// 해당 csv 파일을 읽어 파싱해옵니다. Resources 하위의 경로를 입력으로 받습니다.
    /// </summary>
    public static List<Dictionary<string, object>> ReadFromFile(string fileName)
    {
        TextAsset data = Resources.Load(fileName) as TextAsset;
        return Read(data);
    }

    public static List<Dictionary<string, object>> Read(TextAsset data)
    {
        return Read(data.text);
    }

    public static List<Dictionary<string, object>> Read(string data)
    {
        var list = new List<Dictionary<string, object>>();

        var lines = Regex.Split(data, LINE_SPLIT_RE);

        if (lines.Length <= 1) return list;

        var header = Regex.Split(lines[0], SPLIT_RE);
        for (var i = 1; i < lines.Length; i++)
        {

            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;

            var entry = new Dictionary<string, object>();
            for (var j = 0; j < header.Length && j < values.Length; j++)
            {
                string value = values[j];
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                object finalvalue = value;
                int n;
                float f;
                if (int.TryParse(value, out n))
                {
                    finalvalue = n;
                }
                else if (float.TryParse(value, out f))
                {
                    finalvalue = f;
                }
                entry[header[j]] = finalvalue;
            }
            list.Add(entry);
        }
        return list;
    }
}