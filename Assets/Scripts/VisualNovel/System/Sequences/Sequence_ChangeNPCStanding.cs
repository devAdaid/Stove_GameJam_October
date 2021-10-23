using UnityEngine;

public class Sequence_ChangeNPCStanding : VisualNovelSequence
{
    public override bool NeedWait => false;

    private NPCType _npc;
    private EmotionType _emotion;

    public Sequence_ChangeNPCStanding(IVisualNovelAPI api, NPCType npc, EmotionType emotion) : base(api)
    {
        _npc = npc;
        _emotion = emotion;
    }

    public override void Execute()
    {
        if (!_api.IsNPCStandingVisible)
        {
            _api.ShowNPCStanding();
        }

        var npcData = Global.NPCs.GetData(_npc);
        var standingSprite = GetStandingSprite(_emotion, npcData);
        _api.SetNPCStanding(standingSprite);
    }

    private Sprite GetStandingSprite(EmotionType emotion, NPCStaticDataRecord npcData)
    {
        switch (emotion)
        {
            case EmotionType.Idle:
                return npcData.StandingSprite_Idle;
            case EmotionType.Positive:
                return npcData.StandingSprite_Positive;
            case EmotionType.Negative:
                return npcData.StandingSprite_Negative;
        }

        return null;
    }
}