using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimeManager : MonoBehaviour
{
    [SerializeField] IngameManager _manager;
    [SerializeField] EnemyGenerator _generator;
    [SerializeField] TextMeshProUGUI _countDownText;
    [SerializeField] TextMeshProUGUI _timerText;
    [SerializeField] InputActionAsset _action;
    [SerializeField] int _countDown = 3;
    [SerializeField] int _timeLimit = 60;
    bool _isMeasuring;
    float _delta;

    public void Init()
    {
        _action.Disable();
        _delta = _timeLimit;
        _timerText.text = _delta.ToString("0.0");
        _countDownText.text = "";
    }

    public async UniTask StartCountDown()
    {
        for (int i = _countDown; i > 0; i--)
        {
            _countDownText.text = i.ToString();
            var s = DOTween.Sequence();
            s.Append(_countDownText.transform.DOLocalRotate(new Vector3(0, 0, -360), 0.5f, RotateMode.FastBeyond360).SetDelay(0.5f));
            s.Join(_countDownText.transform.DOScale(0, 0.5f));
            s.Play().OnComplete(() => _countDownText.transform.localScale = Vector3.one);
            await UniTask.Delay(TimeSpan.FromSeconds(1));
        }
        _countDownText.text = "Start!";
        _countDownText.DOFade(0, 0.5f).SetDelay(0.5f);
        await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
        _action.Enable();
        _generator?.GenerateEnemy();
        _isMeasuring = true;
    }

    private void Update()
    {
        if (_isMeasuring)
        {
            _delta -= Time.deltaTime;
            if (_delta <= 0)
            {
                _isMeasuring = false;
                _delta = 0;
                _manager?.SceneChange();
            }
            _timerText.text = _delta.ToString("0.0");
        }
    }
}
