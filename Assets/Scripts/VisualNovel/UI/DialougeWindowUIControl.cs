using RedBlueGames.Tools.TextTyper;
using TMPro;
using UnityEngine;

public class DialougeWindowUIControl : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _nameText;

    [SerializeField]
    private TMP_Text _dialougeText;

    [SerializeField]
    private TextTyper _dialougeTextTyper;

    public void SetNameText(string text)
    {
        _nameText.text = text;
    }

    public void TypeDialogueText(string text)
    {
        _dialougeTextTyper.TypeText(text);
    }

    public bool TrySkipDialogueTyping()
    {
        if (_dialougeTextTyper.IsSkippable() && _dialougeTextTyper.IsTyping)
        {
            _dialougeTextTyper.Skip();
            return true;
        }

        return false;
    }
}
