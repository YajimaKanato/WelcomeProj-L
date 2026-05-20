using DG.Tweening;
using UnityEngine;

public class ResultManager : ManagerBase
{
    public override void FadeIn()
    {
        _image.DOFade(0, 1).OnComplete(() => _image.enabled = false);
    }
}
