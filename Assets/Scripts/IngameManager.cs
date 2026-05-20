using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngameManager : ManagerBase
{
    [SerializeField] TimeManager _manager;
    [SerializeField] TextMeshProUGUI _scoreText;

    public override void FadeIn()
    {
        _manager.Init();
        _image.DOFade(0, 1).OnComplete(() => _manager.StartCountDown().Forget());
        UpdateScore();
    }

    public void UpdateScore()
    {
        var score = ScoreManager.Instance.CurretnScore;
        _scoreText.text = score.ToString("00000");
    }
}
