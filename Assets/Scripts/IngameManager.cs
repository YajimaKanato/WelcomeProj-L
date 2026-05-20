using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class IngameManager : ManagerBase
{
    [SerializeField] TimeManager _manager;

    public override void FadeIn()
    {
        _manager.Init();
        _image.DOFade(0, 1).OnComplete(() => _manager.StartCountDown().Forget());
    }
}
