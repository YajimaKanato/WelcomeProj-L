using UnityEngine;

public class PlayerStatusExecute : MonoBehaviour
{
    [Header("PlayerのHP")]
    [SerializeField] private PlayerDefaultStatus _player;
    [SerializeField] PlayerShot _playerShot;
    [SerializeField] PlayerHPBar _hpBar;

    private PlayerStatus _playerStatus;

    private void OnEnable()
    {
        _playerStatus = new PlayerStatus(_player);
        _playerShot?.SetPlayerInstance(_playerStatus);
    }

    public void ChangeHP(int damage)
    {
        if (_playerStatus.DecreaseHP(damage)) FindFirstObjectByType<TimeManager>()?.StopTimer();
        _hpBar?.UpdateBar(_playerStatus.Rate);
    }

    public void ChangeDirection(int move)
    {
        _playerStatus.SelectDirection(move);
    }

    public void ChangeType(int move)
    {
        _playerStatus.SelectType(move);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            ChangeHP(1);
        }
    }
}
