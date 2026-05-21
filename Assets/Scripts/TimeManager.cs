using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimeManager : MonoBehaviour
{
    [SerializeField] IngameManager _manager;
    [SerializeField] PlayerShot _player;
    [SerializeField] PlayerMove _playerMove;
    [SerializeField] PlayerStatusExecute _playerStatus;
    [SerializeField] EnemyGenerator _generator;
    [SerializeField] TextMeshProUGUI _countDownText;
    [SerializeField] TextMeshProUGUI _timerText;
    [SerializeField] int _countDown = 3;
    [SerializeField] int _timeLimit = 60;
    bool _isMeasuring;
    float _delta;

    public void Init()
    {
        _delta = _timeLimit;
        _timerText.text = _delta.ToString("0.0");
        _countDownText.text = "";
        _player.CanShot = false;
        _playerMove.CanMove = false;
        _playerStatus.CanHit = false;
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
        _player.CanShot = true;
        _playerMove.CanMove = true;
        _playerStatus.CanHit = true;
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
                StopTimer();
                _delta = 0;
            }
            _timerText.text = _delta.ToString("0.0");
        }
    }

    public void StopTimer()
    {
        if (_isMeasuring) _manager?.SceneChange();
        _isMeasuring = false;
    }
}
