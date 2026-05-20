using UnityEngine;

public class SceneManager : MonoBehaviour
{
    static SceneManager instance;
    public static SceneManager Instance { get { return instance; } }
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SceneChange(string SceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
    }
}
