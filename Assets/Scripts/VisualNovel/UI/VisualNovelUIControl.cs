using RedBlueGames.Tools.TextTyper;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VisualNovelUIControl : MonoBehaviour
{
    public Image BackgroundImage;
    public Image NpcStandingImage;
    public TMP_Text NameText;
    public TextTyper TextTyper;
    public TMP_Text Option1Text;
    public TMP_Text Option2Text;
    public Button Option1Button;
    public Button Option2Button;
    public Button InputBlockButton;
    public GameObject OptionButtonRoot;
    public GameObject TextWindowRoot;
    public GameObject NamePlateRoot;
    public GameObject NPCStandingRoot;

    void Awake()
    {
        BackgroundImage.gameObject.SetActive(false);
        NPCStandingRoot.SetActive(false);
        NamePlateRoot.SetActive(false);
        TextWindowRoot.SetActive(false);
        OptionButtonRoot.SetActive(false);
    }
}
