using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : PersistentSingleton<SoundManager>
{
    [SerializeField]
    private AudioSource _bgmSource;

    [SerializeField]
    private AudioSource _sfxSource;

    private Dictionary<string, AudioClip> _clips;

    protected override void Awake()
    {
        base.Awake();

        var clips = Resources.LoadAll<AudioClip>("AudioClips");
        _clips = clips.ToDictionary(x => x.name, x => x);
    }

    public void StopBgm()
    {
        _bgmSource.clip = null;
    }

    public void PlayBgm(string clipName)
    {
        if (_clips.TryGetValue(clipName, out var clip))
        {
            _bgmSource.clip = clip;
            _bgmSource.Play();
        }
        else
        {
            _bgmSource.clip = null;
        }
    }

    public void PlaySfx(string clipName)
    {
        if (_clips.TryGetValue(clipName, out var clip))
        {
            _sfxSource.PlayOneShot(clip);
        }
    }

    public void PlaySfxNotOneShot(string clipName)
    {
        if (_clips.TryGetValue(clipName, out var clip))
        {
            _bgmSource.clip = clip;
            _bgmSource.Play();
        }
    }
}