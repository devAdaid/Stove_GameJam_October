using UnityEngine;

public interface IVisualNovelAPI
{
    bool IsTextWindowVisible { get; }
    void ShowTextWindow();
    void HideTextWindow();

    void SetNamePlateText(string text);
    bool IsNamePlateVisible { get; }
    void ShowNamePlate();
    void HideNamePlate();

    void Advance();

    void TypeText(string text);

    void SetBackground(Sprite sprite);
    bool IsBackgroundVisible { get; }
    void ShowBackground();
    void HideBackground();

    void SetNPCStanding(Sprite sprite);
    bool IsNPCStandingVisible { get; }
    void ShowNPCStanding();
    void HideNPCStanding();

    int GetCurrentStatValue(StatType stat);
    void ApplyResultStat(StatValue statValue);

    void ShowOptions(string option1, string option2);
    void SelectOption(int option);
}