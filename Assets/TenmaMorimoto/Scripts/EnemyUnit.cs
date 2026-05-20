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
    private float _timer = 3f;

    

   

    private void FixedUpdate()
    {
        ShootInterval();
    }





    void BulletCurrent(MinoType minoType, MinoDirection minoDirection)
    {
        if (_type == minoType && _direction == minoDirection)
        {
            _difenceCurrent++;
            if (_difenceCurrent >= _difenceCount)
            {
                Destroy(gameObject);
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        BulletCurrent(MinoType.NormalL, MinoDirection.Up);

    }



    void ShootInterval()
    {
        _timer += Time.fixedDeltaTime;
        if (_timer >= _bulletInterbal)
        {
            BulletShoot();
            _timer -= _bulletInterbal;
        }
    }
    void BulletShoot()
    {
        GameObject Bullet = Instantiate(_bullet, transform.position, transform.rotation);

        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(_bulletSpeed * Vector2.left, ForceMode2D.Impulse);
    }


}
