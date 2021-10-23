using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatEntry : MonoBehaviour
{
    [SerializeField]
    private Image _icon;
    [SerializeField]
    private TMP_Text _statText;

    public void SetEntry(Sprite iconSprite, string statName, int value)
    {
        _icon.sprite = iconSprite;
        _statText.text = $"{statName} - {value}";
    }
}
