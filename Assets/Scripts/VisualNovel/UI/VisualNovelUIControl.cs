using System.Collections.Generic;
using RedBlueGames.Tools.TextTyper;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VisualNovelUIControl : MonoSingleton<VisualNovelUIControl>
{
    public LocationSelectUI LocationSelectUI;
    public List<StatEntry> StatEntries;

    public Image BackgroundImage;
    public Image NpcStandingImage;
    public TMP_Text NameText;
    public TextTyper TextTyper;
    public TMP_Text Option1Text;
    public TMP_Text Option2Text;
    public Button Option1Button;
    public Button Option2Button;
    public Button InputBlockButton;
    public GameObject SimpleStatRoot;
    public GameObject OptionButtonRoot;
    public GameObject TextWindowRoot;
    public GameObject NamePlateRoot;
    public GameObject NPCStandingRoot;
    public GameObject TextArrowRoot;

    void Awake()
    {
        LocationSelectUI.gameObject.SetActive(false);
        BackgroundImage.gameObject.SetActive(false);
        InputBlockButton.gameObject.SetActive(false);
        NPCStandingRoot.SetActive(false);
        NamePlateRoot.SetActive(false);
        TextWindowRoot.SetActive(false);
        TextArrowRoot.SetActive(false);
        SimpleStatRoot.SetActive(false);

        TextTyper.PrintCompleted.AddListener(() => TextArrowRoot.SetActive(true));
    }
}
