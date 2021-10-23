using UnityEngine;

public interface IVisualNovelAPI
{
    void TypeText(string text);
    void ChangeBackground(Sprite sprite);
    void ApplyResultStat(StatValue statValue);
    void PlayOptionalDialouge(int option);
}