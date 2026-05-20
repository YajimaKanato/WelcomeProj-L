using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    static ScoreManager _instance;
    public static ScoreManager Instance => _instance;
    int _curretnScore = 0;
    public int CurretnScore => _curretnScore;
    List<int> _ranking = new() { 0, 0, 0, 0, 0 };
    public IReadOnlyList<int> Ranking => _ranking;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += ResetScore;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [ContextMenu("UpdateScore")]
    void DemoUpdateScore()
    {
        UpdateScore(100);
    }

    public void UpdateScore(int score)
    {
        _curretnScore += score;
    }

    public void CalculateRanking()
    {
        _ranking.Add(_curretnScore);
        _ranking = _ranking.OrderByDescending(x => x).Take(5).ToList();
    }

    void ResetScore(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "Ingame":
                _curretnScore = 0;
                break;
            case "Result":
                CalculateRanking();
                break;
        }
    }
}
