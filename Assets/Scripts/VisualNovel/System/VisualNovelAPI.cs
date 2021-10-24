using DG.Tweening;
using UnityEngine;

public class VisualNovelAPI : IVisualNovelAPI
{
    private bool _isTextWindowVisible = false;

    private bool _isNamePlateVisible = false;

    private bool _isBackgroundVisible = true;

    private bool _isNPCStandingVisible = false;

    private VisualNovelUIControl ui => VisualNovelUIControl.Instance;
    private IVisualNovelContext context;

    public VisualNovelAPI(IVisualNovelContext novelContext)
    {
        context = novelContext;

        ui.InputBlockButton.onClick.AddListener(Advance);
        ui.Option1Button.onClick.AddListener(() => SelectOption(1));
        ui.Option2Button.onClick.AddListener(() => SelectOption(2));
    }

    public void SetContext(IVisualNovelContext novelContext)
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
        if (!context.CanSelectOption())
        {
            return;
        }

        var buttonSequence = DOTween.Sequence();
        buttonSequence.Append(ui.Option1Button.transform.DOLocalMoveX(650f, 0.3f));
        buttonSequence.Insert(0.1f, ui.Option2Button.transform.DOLocalMoveX(700f, 0.3f));
        buttonSequence.Play();
        context.SelectOption(option);
    }

    public void ApplyResultStat(StatValue statValue)
    {
        if (statValue.Value > 0)
        {
            SoundManager.Instance.PlaySfx("StatUp");
        }
        else if (statValue.Value < 0)
        {
            SoundManager.Instance.PlaySfx("StatDown");
        }

        Global.Player.Stat.AddStat(statValue);
        UpdateSimpleStats();
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
        ui.TextArrowRoot.SetActive(false);
        ui.TextTyper.TypeText(text);
    }

    public void ShowOptions(string option1, string option2)
    {
        var buttonSequence = DOTween.Sequence();
        buttonSequence.Append(ui.Option1Button.transform.DOLocalMoveX(-50f, 0.3f));
        buttonSequence.Insert(0.1f, ui.Option2Button.transform.DOLocalMoveX(-100f, 0.3f));
        buttonSequence.Play();
        ui.Option1Text.text = option1;
        ui.Option2Text.text = option2;

        TutorialUI.Instance.TryShowSelectTutorial();
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


    private static readonly StatType[] STATS = new StatType[]
    {
        StatType.Action,
        StatType.Horror,
        StatType.Detective,
        StatType.Romance,
        StatType.OrientalFantasy,
        StatType.Fantasy,
    };

    public void UpdateSimpleStats()
    {
        for (int i = 0; i < 6; i++)
        {
            var data = Global.Stats.GetData(STATS[i]);
            var value = Global.Player.Stat.GetStat(STATS[i]);
            ui.StatEntries[i].SetEntry(data.IconSprite, data.DisplayName, value);
        }
    }

    public void ShowSimpleStats()
    {
        ui.SimpleStatRoot.SetActive(true);
        UpdateSimpleStats();
    }

    public void HideSimpleStats()
    {
        ui.SimpleStatRoot.SetActive(false);
    }
}