using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    [SerializeField] AudioClipInfo[] _clips;
    Dictionary<string, AudioClip> _clipDict;
    AudioSource _audioSource;

    static BGMManager _instance;
    public static BGMManager Instance => _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            _clipDict = new Dictionary<string, AudioClip>();
            foreach (var clip in _clips)
            {
                _clipDict.Add(clip.SeName, clip.Clip);
            }
            _audioSource = GetComponent<AudioSource>();
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += BGMChange;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void BGMChange(Scene scene, LoadSceneMode mode)
    {
        if (_clipDict.TryGetValue(scene.name,out var clip))
        {
            _audioSource.clip = clip;
            _audioSource.loop = true;
            _audioSource.Play();
        }
    }
}
