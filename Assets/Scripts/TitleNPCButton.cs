using UnityEngine;
using UnityEngine.UI;

public class TitleNPCButton : MonoBehaviour
{
    public GameObject Lock;
    public Button Button;

    void Start()
    {
        var isCleared = PlayerPrefs.HasKey("Clear");
        Button.interactable = isCleared;
        Lock.SetActive(!isCleared);
    }
}
