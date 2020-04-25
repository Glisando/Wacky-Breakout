using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class AudioManager
{
    static AudioSource _audioSource;
    static bool initialized = false;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    static public bool Initialized
    {
        get { return initialized; }
    }

    static public void Initialize(AudioSource source)
    {
        initialized = true;
        _audioSource = source;

        audioClips.Add(AudioClipName.Click,
            Resources.Load<AudioClip>("ButtonClick"));
        audioClips.Add(AudioClipName.Win,
            Resources.Load<AudioClip>("Win"));
        audioClips.Add(AudioClipName.GameOver,
            Resources.Load<AudioClip>("GameOver"));
        audioClips.Add(AudioClipName.Speedup,
            Resources.Load<AudioClip>("Speedup"));
        audioClips.Add(AudioClipName.Freeze,
            Resources.Load<AudioClip>("Freeze"));
        audioClips.Add(AudioClipName.BlockHit,
            Resources.Load<AudioClip>("BlockHit"));
        audioClips.Add(AudioClipName.PaddleHit,
            Resources.Load<AudioClip>("PaddleHit"));
    }

    static public void Play(AudioClipName name)
    {
        _audioSource.PlayOneShot(audioClips[name]);
    }
}
