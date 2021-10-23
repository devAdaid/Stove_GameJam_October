public class Sequence_NPCDialogueText : VisualNovelSequence
{
    public override bool NeedWait => true;

    private NPCType _npc;
    private string _dialogueText;

    public Sequence_NPCDialogueText(IVisualNovelAPI api, NPCType npc, string dialogueText) : base(api)
    {
        _npc = npc;
        _dialogueText = dialogueText;
    }

    public override void Execute()
    {
        if (!_api.IsTextWindowVisible)
        {
            _api.ShowTextWindow();
        }

        if (!_api.IsNamePlateVisible)
        {
            _api.ShowNamePlate();
        }

        var npcData = Global.NPCs.GetData(_npc);
        _api.SetNamePlateText(npcData.DisplayName);
        _api.TypeText(_dialogueText);
    }
}