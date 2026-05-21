using UnityEngine;

public class titledirection : MonoBehaviour
{
    [Header("アニメーター")]
    [SerializeField] private Animator _animetor;

    public　void TitleAnime()
    {
        _animetor.SetTrigger("start");
    }
}

