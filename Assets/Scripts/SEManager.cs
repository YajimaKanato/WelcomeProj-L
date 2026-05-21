using System;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    [SerializeField] AudioClipInfo[] _clips;
    Dictionary<string, AudioClip> _clipDict;
    AudioSource _audioSource;

    static SEManager _instance;
    public static SEManager Instance => _instance;

    private void Awake()
    {
        if( _instance == null)
        {
            _instance = this;
            _clipDict = new Dictionary<string, AudioClip>();
            foreach(var clip in _clips)
            {
                _clipDict.Add(clip.SeName, clip.Clip);
            }
            _audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySE(string seName)
    {
        if (_clipDict.TryGetValue(seName, out var clip)) _audioSource.PlayOneShot(clip);
    }
}

[Serializable]
public class AudioClipInfo
{
    [SerializeField] AudioClip _clip;
    [SerializeField] string _clipName;

    public AudioClip Clip => _clip;
    public string SeName => _clipName;
}