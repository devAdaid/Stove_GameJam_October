using UnityEngine;

public class VisualNovelAPI : IVisualNovelAPI
{
    private bool _isTextWindowVisible = false;

    private bool _isNamePlateVisible = false;

    private bool _isBackgroundVisible = true;

    private bool _isNPCStandingVisible = false;

    private readonly VisualNovelUIControl ui;
    private VisualNovelContext context;

    public VisualNovelAPI(VisualNovelUIControl uIControl, VisualNovelContext novelContext)
    {
        ui = uIControl;
        context = novelContext;

        ui.InputBlockButton.onClick.AddListener(Advance);
        ui.Option1Button.onClick.AddListener(() => SelectOption(1));
        ui.Option2Button.onClick.AddListener(() => SelectOption(2));
    }

    public void SetContext(VisualNovelContext novelContext)
    {
        context = novelContext;
    }

    public bool IsTextWindowVisible => _isTextWindowVisible;

    public bool IsNamePlateVisible => _isNamePlateVisible;

    public bool IsBackgroundVisible => _isBackgroundVisible;

    public bool IsNPCStandingVisible => _isNPCStandingVisible;

    public void Advance()
    {
        if (ui.TextTyper.IsSkippable() && ui.TextTyper.IsTyping)
        {
            ui.TextTyper.Skip();
        }
        else
        {
            context.AdvanceSequence();
        }
    }

    public void SelectOption(int option)
    {
        ui.OptionButtonRoot.SetActive(false);
        context.SelectOption(option);
    }

    public void ApplyResultStat(StatValue statValue)
    {
        Global.Player.Stat.AddStat(statValue);
    }

    public int GetCurrentStatValue(StatType stat)
    {
        return Global.Player.Stat.GetStat(stat);
    }

    public void HideBackground()
    {
        ui.BackgroundImage.gameObject.SetActive(false);
        _isBackgroundVisible = false;
    }

    public void HideNamePlate()
    {
        ui.NamePlateRoot.SetActive(false);
        _isNamePlateVisible = false;
    }

    public void HideNPCStanding()
    {
        ui.NPCStandingRoot.SetActive(false);
        _isNPCStandingVisible = false;
    }

    public void HideTextWindow()
    {
        ui.TextWindowRoot.SetActive(false);
        _isTextWindowVisible = false;
    }

    public void SetBackground(Sprite sprite)
    {
        ui.BackgroundImage.sprite = sprite;
    }

    public void SetNamePlateText(string text)
    {
        ui.NameText.text = text;
    }

    public void SetNPCStanding(Sprite sprite)
    {
        ui.NpcStandingImage.sprite = sprite;
    }

    public void ShowBackground()
    {
        ui.BackgroundImage.gameObject.SetActive(true);
        _isBackgroundVisible = true;
    }

    public void ShowNamePlate()
    {
        ui.NamePlateRoot.SetActive(true);
        _isNamePlateVisible = true;
    }

    public void ShowNPCStanding()
    {
        ui.NPCStandingRoot.SetActive(true);
        _isNPCStandingVisible = true;
    }

    public void ShowTextWindow()
    {
        ui.TextWindowRoot.SetActive(true);
        _isTextWindowVisible = true;
    }

    public void TypeText(string text)
    {
        ui.TextTyper.TypeText(text);
    }

    public void ShowOptions(string option1, string option2)
    {
        ui.Option1Text.text = option1;
        ui.Option2Text.text = option2;
        ui.OptionButtonRoot.SetActive(true);
    }

    public void ShowLocationSelectUI()
    {
        ui.LocationSelectUI.gameObject.SetActive(true);
    }

    public void HideLocationSelectUI()
    {
        ui.LocationSelectUI.gameObject.SetActive(false);
    }

    public void UpdateLocationSelectUI()
    {
        ui.LocationSelectUI.UpdateUI();
    }

    public void SetInputBlockerEnable(bool enable)
    {
        ui.InputBlockButton.gameObject.SetActive(enable);
    }
}