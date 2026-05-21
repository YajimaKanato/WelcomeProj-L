using DG.Tweening;
using UnityEngine;

public class TitleManager : ManagerBase
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public override void FadeIn()
    {
        _image.DOFade(0, 1).OnComplete(() => _image.enabled = false);
    }
}
