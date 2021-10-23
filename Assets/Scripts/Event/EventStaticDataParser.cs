using System;
using System.Collections.Generic;

public static class EventStaticDataParser
{
    #region Constants
    private static readonly string FILE_PATH = "Data/Event.csv";
    private static readonly string ROW_ID = "EventId";
    private static readonly string ROW_DAY_RANGE = "DayRange";
    private static readonly string ROW_NPC = "NPC";
    private static readonly string ROW_DIALOGUE_TEXT1 = "DialougeText1";
    private static readonly string ROW_DIALOGUE_TEXT2 = "DialougeText2";

    private static readonly string ROW_GROUP_OPTION1 = "Option1";
    private static readonly string ROW_GROUP_OPTION2 = "Option2";

    private static readonly string ROW_OPTION_TEXT = "OptionText";
    private static readonly string ROW_OPTION_SUCCESS_REACTION_TEXT = "SucessReactionText";
    private static readonly string ROW_OPTION_FAIL_REACTION_TEXT = "FailReactionText";
    private static readonly string ROW_OPTION_STANDARD_STAT_TYPE = "StandardStatType";
    private static readonly string ROW_OPTION_STANDARD_STAT_VALUE = "StandardStatValue";
    private static readonly string ROW_OPTION_RESULT_STAT_TYPE = "ResultStatType";
    private static readonly string ROW_OPTION_RESULT_STAT_VALUE = "ResultStatValue";
    #endregion

    public static List<EventStaticDataRecord> GetParsed()
    {
        var result = new List<EventStaticDataRecord>();
        var csvParsed = CSVParser.ReadFromFile(FILE_PATH);
        foreach (var rowDict in csvParsed)
        {
            var id = (string)rowDict[ROW_ID];
            var dayRange = (DayRangeType)Enum.Parse(typeof(DayRangeType), (string)rowDict[ROW_DAY_RANGE]);
            var npc = (NPCType)Enum.Parse(typeof(NPCType), (string)rowDict[ROW_NPC]);

            var dialougeText1 = (string)rowDict[ROW_DIALOGUE_TEXT1];
            var dialougeText2 = (string)rowDict[ROW_DIALOGUE_TEXT2];
            var dialougeTexts = new List<string>() { dialougeText1, dialougeText2 };

            var option1 = ParseOption(ROW_GROUP_OPTION1, rowDict);
            var option2 = ParseOption(ROW_GROUP_OPTION2, rowDict);

            var record = new EventStaticDataRecord(id, dayRange, npc, dialougeTexts, option1, option2);
            result.Add(record);
        }
        return result;
    }

    private static EventStaticDataRecordOption ParseOption(string optionKey, Dictionary<string, object> rowDict)
    {
        var optionText = (string)rowDict[string.Join("_", optionKey, ROW_OPTION_TEXT)];
        var successReactionText = (string)rowDict[string.Join("_", optionKey, ROW_OPTION_SUCCESS_REACTION_TEXT)];
        var failReactionText = (string)rowDict[string.Join("_", optionKey, ROW_OPTION_FAIL_REACTION_TEXT)];
        var standardStatType = (StatType)Enum.Parse(typeof(StatType), (string)rowDict[string.Join("_", optionKey, ROW_OPTION_STANDARD_STAT_TYPE)]);
        var resultStatType = (StatType)Enum.Parse(typeof(StatType), (string)rowDict[string.Join("_", optionKey, ROW_OPTION_RESULT_STAT_TYPE)]);
        var resultStatValue = (int)rowDict[string.Join("_", optionKey, ROW_OPTION_RESULT_STAT_VALUE)];

        return new EventStaticDataRecordOption(
            optionText,
            successReactionText,
            failReactionText,
            standardStatType,
            new StatValue(resultStatType, resultStatValue)
        );
    }
}