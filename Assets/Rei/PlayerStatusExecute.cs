using UnityEngine;

public class PlayerStatusExecute : MonoBehaviour
{
    [Header("PlayerのHP")]
    [SerializeField] private int _playerHP;

    private PlayerStatus _playerStatus;

    private void OnEnable()
    {
        _playerStatus = new PlayerStatus(_playerHP);
    }

    private void OnDisable()
    {

    }

    private void ChangeHP(int damage)
    {
        _playerStatus.DecreaseHP(damage);
    }

    private void ChangeDirection()
    {
        _playerStatus.SelectDirection();
    }

    private void ChangeType()
    {
        _playerStatus.SelectType();
    }
}
