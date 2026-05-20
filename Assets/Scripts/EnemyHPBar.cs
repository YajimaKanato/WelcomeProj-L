using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBar : MonoBehaviour
{
    [SerializeField] Image _bar;
    [SerializeField] float _decreasingSpeed = 0.5f;

    public void UpdateBar(float rate)
    {
        if (!_bar) return;
        _bar.DOFillAmount(rate, _decreasingSpeed).SetLink(gameObject);
    }
}
