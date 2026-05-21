using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    [Header("自分のスコア")]
    [SerializeField] private TextMeshProUGUI _myScore;
    [Header("その他のスコア")]
    [SerializeField] TextMeshProUGUI[] _scores;
    [SerializeField] CanvasGroup _canvasGroup;

    private void Start()
    {
        CurrentRank();
        foreach (var score in _scores)
        {
            score.text = "";
        }
        _canvasGroup.alpha = 0;
    }

    public void CurrentRank()
    {
        var currentScore = 0;

        DOTween.To(() => currentScore,
        x =>
        {
            currentScore = x;
            _myScore.text = currentScore.ToString();
        },
         ScoreManager.Instance.CurretnScore,
         2f);

        StartCoroutine(OtherRank());
    }

    private IEnumerator OtherRank()
    {
        yield return new WaitForSeconds(2f);
        var ranking = ScoreManager.Instance.Ranking;
        for (int i = 0; i < ranking.Count; i++)
        {
            _scores[i].text = (i + 1) + " : " + ranking[i].ToString("00000");
        }
        var s = DOTween.Sequence();
        s.Append(transform.DOLocalMoveX(490f, 3f));
        s.Join(_canvasGroup.DOFade(1, 3));
        yield return null;
    }
}
