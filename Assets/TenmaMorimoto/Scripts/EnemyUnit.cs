using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    [SerializeField] GameObject _bullet;

    [SerializeField] MinoDirection _direction;
    [SerializeField] MinoType _type;

    [SerializeField] int _difenceCount = 3;
    int _difenceCurrent;

    [SerializeField] private float _bulletInterbal = 0.5f;
    [SerializeField] private float _bulletSpeed = 5f;
    [SerializeField] int _score = 10;
    private float _timer = 3f;
    IngameManager _gameManager;
    Enemy _enemy;

    private void Start()
    {

        _gameManager = FindFirstObjectByType<IngameManager>();
    }



    private void Update()
    {
        ShootInterval();
    }





    void BulletCurrent(MinoType minoType, MinoDirection minoDirection)
    {
        if (_type == minoType && _direction == minoDirection)
        {
            //Debug.Log("Correct Hit");
            _difenceCurrent++;
            if (_difenceCurrent >= _difenceCount)
            {
                ScoreManager.Instance.UpdateScore(_score);
                _gameManager?.UpdateScore();
                _enemy?.Damage();
                Destroy(gameObject);
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lmino") && other.gameObject.TryGetComponent<PlayerBulletMove>(out var player))
        {
            BulletCurrent(player.Type, player.Direction);
        }
    }



    void ShootInterval()
    {
        _timer += Time.deltaTime;
        if (_timer >= _bulletInterbal)
        {
            BulletShoot();
            _timer = 0;
        }
    }
    void BulletShoot()
    {
        if (!_bullet) return;
        GameObject Bullet = Instantiate(_bullet, transform.position, transform.rotation);
    }

    public void SetParentEnemy(Enemy enemy)
    {
        _enemy = enemy;
    }
}
