using UnityEngine;
using UnityEngine.UI;

public class NPCSelectButton : MonoBehaviour
{
    public NPCType NPC;
    public Image Profile;

    private NPCStaticDataRecord _data;

    void Start()
    {
        _data = NPCGlobal.Instance.NPCs.GetData(NPC);
        Profile.sprite = _data.ProfileSprite;
    }

    public void OnClick()
    {
        NPCInfoUI.Instance.SetUI(_data);
    }
}
