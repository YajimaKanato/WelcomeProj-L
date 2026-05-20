using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    static ScoreManager _instance;
    public static ScoreManager Instance => _instance;
    int _curretnScore = 0;
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

    public void UpdateScore(int score)
    {
        _curretnScore += score;
    }

    public void CalculateRanking(int score)
    {
        _ranking.Add(score);
        _ranking = _ranking.OrderByDescending(x => x).Take(5).ToList();
    }

    void ResetScore(Scene scene,LoadSceneMode mode)
    {
        if (scene.name == "Ingame") _curretnScore = 0;
    }
}
