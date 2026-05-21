using DG.Tweening;

public class TitleManager : ManagerBase
{
    public override void FadeIn()
    {
        _image.DOFade(0, 1).OnComplete(() => _image.enabled = false);
    }
}
