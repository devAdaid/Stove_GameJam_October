using UnityEngine;

public class TutorialUI : MonoSingleton<TutorialUI>
{
    public GameObject PlayTutorialUI;
    public GameObject SelectTutorialUI;

    public void TryShowPlayTutorial()
    {
        var isCleared = PlayerPrefs.HasKey("Tutorial_Play");
        if (!isCleared)
        {
            PlayTutorialUI.SetActive(true);
            PlayerPrefs.SetInt("Tutorial_Play", 0);
            PlayerPrefs.Save();
        }
    }

    public void TryShowSelectTutorial()
    {
        var isCleared = PlayerPrefs.HasKey("Tutorial_Select");
        if (!isCleared)
        {
            SelectTutorialUI.SetActive(true);
            PlayerPrefs.SetInt("Tutorial_Select", 0);
            PlayerPrefs.Save();
        }
    }
}
