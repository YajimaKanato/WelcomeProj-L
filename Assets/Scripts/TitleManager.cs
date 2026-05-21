using DG.Tweening;

public class TitleManager : ManagerBase
{
    public override void FadeIn()
    {
        _image.DOFade(0, 1).OnComplete(() => _image.enabled = false);
    }

    public override void SceneChange()
    {
        _image.enabled = true;
        _image.DOFade(1, 2.5f).SetEase(Ease.InExpo).OnComplete(() => SceneManager.Instance.SceneChange(_sceneName));
    }
}
