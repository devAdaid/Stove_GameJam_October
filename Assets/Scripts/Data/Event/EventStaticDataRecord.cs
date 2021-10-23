using System.Collections.Generic;

public class EventStaticDataRecordOption
{
    /// <summary>
    /// 선택지 텍스트
    /// </summary>
    public readonly string OptionText;

    /// <summary>
    /// NPC 반응 텍스트 (성공)
    /// </summary>
    public readonly string SucessReactionText;

    /// <summary>
    /// NPC 반응 텍스트 (실패)
    /// </summary>
    public readonly string FailReactionText;

    /// <summary>
    /// 기준치 스탯 값
    /// </summary>
    public readonly StatType StandardStatType;

    /// <summary>
    /// 결과 증감 스탯 값
    /// </summary>
    public readonly StatValue ResultStatValue;

    public EventStaticDataRecordOption(string optionText, string successReactionText, string failReactionText, StatType standardStatType, StatValue resultStatValue)
    {
        OptionText = optionText;
        SucessReactionText = successReactionText;
        FailReactionText = failReactionText;
        StandardStatType = standardStatType;
        ResultStatValue = resultStatValue;
    }
}

public class EventStaticDataRecord
{
    /// <summary>
    /// 이벤트의 구별자
    /// </summary>
    public readonly string Id;

    /// <summary>
    /// 등장 날짜 범위
    /// </summary>
    public readonly DayRangeType DayRange;

    /// <summary>
    /// 만나는 NPC
    /// </summary>
    public readonly NPCType NPC;

    /// <summary>
    /// 대사 텍스트
    /// </summary>
    public readonly List<string> DialogueTexts;

    /// <summary>
    /// 선택지1 정보
    /// </summary>
    public readonly EventStaticDataRecordOption Option1;

    /// <summary>
    /// 선택지2 정보
    /// </summary>
    public readonly EventStaticDataRecordOption Option2;

    public EventStaticDataRecord(string id, DayRangeType dayRange, NPCType npc, List<string> dialogueTexts, EventStaticDataRecordOption option1, EventStaticDataRecordOption option2)
    {
        Id = id;
        DayRange = dayRange;
        NPC = npc;
        DialogueTexts = dialogueTexts;
        Option1 = option1;
        Option2 = option2;
    }
}