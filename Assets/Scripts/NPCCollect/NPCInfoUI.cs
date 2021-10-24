using TMPro;
using UnityEngine.UI;

public class NPCInfoUI : MonoSingleton<NPCInfoUI>
{
    public TMP_Text NameText;
    public TMP_Text IdeaText;

    public Image Full_Idle;
    public Image Full_Positive;
    public Image Full_Negative;

    void Start()
    {
        SetUI(NPCGlobal.Instance.NPCs.GetData(NPCType.Missing));
    }

    public void SetUI(NPCStaticDataRecord data)
    {
        NameText.text = data.DisplayName;
        IdeaText.text = $"{NPCGlobal.Instance.KRStrings.GetString("IdeaGiver")}: {data.IdeaGiver}";
        Full_Idle.sprite = data.FullSprite_Idle;
        Full_Positive.sprite = data.FullSprite_Positive;
        Full_Negative.sprite = data.FullSprite_Negative;
    }
}