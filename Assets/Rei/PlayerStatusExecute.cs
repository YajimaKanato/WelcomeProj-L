using UnityEngine;
using UnityEngine.U2D;

public class PlayerStatusExecute : MonoBehaviour
{
    [Header("PlayerのHP")]
    [SerializeField] private PlayerDefaultStatus _player;
    [SerializeField] PlayerShot _playerShot;
    [SerializeField] PlayerHPBar _hpBar;
    [SerializeField] UnitList _unitList;
    [SerializeField] SpriteRenderer _bullet;
    public bool CanHit;

    private PlayerStatus _playerStatus;

    private void OnEnable()
    {
        _playerStatus = new PlayerStatus(_player);
        _playerShot?.SetPlayerInstance(_playerStatus);
    }

    public void ChangeHP(int damage)
    {
        if (!CanHit) return;
        if (_playerStatus.DecreaseHP(damage)) FindFirstObjectByType<TimeManager>()?.StopTimer();
        _hpBar?.UpdateBar(_playerStatus.Rate);
    }

    public void ChangeDirection(int move)
    {
        _playerStatus.SelectDirection(move);
        foreach (var item in _unitList.UnitsList)
        {
            if ((_playerStatus.Type, _playerStatus.Direction) == (item.Conditions.Type, item.Conditions.MyDirection))
            {
                _bullet.sprite = item.UnitSprite;
                break;
            }
        }
    }

    public void ChangeType(int move)
    {
        _playerStatus.SelectType(move);
        foreach (var item in _unitList.UnitsList)
        {
            if ((_playerStatus.Type, _playerStatus.Direction) == (item.Conditions.Type, item.Conditions.MyDirection))
            {
                _bullet.sprite = item.UnitSprite;
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            ChangeHP(1);
        }
    }
}
