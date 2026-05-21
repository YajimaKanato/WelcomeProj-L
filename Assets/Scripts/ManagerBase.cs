using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public abstract class ManagerBase : MonoBehaviour
{
    [SerializeField] protected Image _image;
    [SerializeField] protected string _sceneName;
    private void Start()
    {
        FadeIn();
    }

    public abstract void FadeIn();

    public virtual void SceneChange()
    {
        _image.enabled = true;
        _image.DOFade(1, 1).OnComplete(() => SceneManager.Instance.SceneChange(_sceneName));
    }
}
