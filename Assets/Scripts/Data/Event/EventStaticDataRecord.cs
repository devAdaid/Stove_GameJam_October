using System.Collections.Generic;

public class EventStaticDataRecordOption
{
    /// <summary>
    /// ������ �ؽ�Ʈ
    /// </summary>
    public readonly string OptionText;

    /// <summary>
    /// NPC ���� �ؽ�Ʈ (����)
    /// </summary>
    public readonly string SucessReactionText;

    /// <summary>
    /// NPC ���� �ؽ�Ʈ (����)
    /// </summary>
    public readonly string FailReactionText;

    /// <summary>
    /// ����ġ ���� ��
    /// </summary>
    public readonly StatType StandardStatType;

    /// <summary>
    /// ��� ���� ���� ��
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
    /// �̺�Ʈ�� ������
    /// </summary>
    public readonly string Id;

    /// <summary>
    /// ���� ��¥ ����
    /// </summary>
    public readonly DayRangeType DayRange;

    /// <summary>
    /// ������ NPC
    /// </summary>
    public readonly NPCType NPC;

    /// <summary>
    /// ��� �ؽ�Ʈ
    /// </summary>
    public readonly List<string> DialogueTexts;

    /// <summary>
    /// ������1 ����
    /// </summary>
    public readonly EventStaticDataRecordOption Option1;

    /// <summary>
    /// ������2 ����
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