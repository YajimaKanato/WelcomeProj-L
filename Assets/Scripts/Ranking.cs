using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    [Header("自分のスコア")]
    [SerializeField] private TextMeshProUGUI _myScore;
    [Header("その他のスコア")]
    [SerializeField] TextMeshProUGUI[] _scores;
   
    private void Start()
    {
        CurrentRank();
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
        transform.DOLocalMoveX(490f, 3f);
        yield return null;
    }
}
