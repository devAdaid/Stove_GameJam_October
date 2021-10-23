using UnityEngine;

public class BgmInitPlayer : MonoBehaviour
{
    public string bgmName;

    void Start()
    {
        SoundManager.Instance.PlayBgm(bgmName);
    }
}
