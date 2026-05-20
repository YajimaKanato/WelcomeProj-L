using TMPro;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] _scores;
    private void Start()
    {
        SetRanking();
    }

    public void SetRanking()
    {
        var ranking = ScoreManager.Instance.Ranking;
        for (int i = 0; i < ranking.Count; i++)
        {
            _scores[i].text = (i + 1) + " : " + ranking[i].ToString("00000");
        }
    }
}
