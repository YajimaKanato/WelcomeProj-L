using UnityEngine;
using UnityEngine.InputSystem; // 新しいInput Systemを使用

public class PlayerShot : MonoBehaviour
{
    [SerializeField] private PlayerBulletMove bulletPrefab;  // 弾プレハブ
    [SerializeField] private Transform spawnPoint;      // 弾の出る位置
    [SerializeField] private float bulletSpeed = 10f;   // 弾速
    [SerializeField] private float fireRate = 0.5f;     // 発射間隔

    private float nextFireTime = 0f;                    // 次に撃てる時刻

    [SerializeField] private InputActionAsset _action;
    private InputAction bulletAction;
    PlayerStatus _status;

    void Start()
    {
        bulletAction = _action.FindActionMap("tg").FindAction("Bullet");
    }

    void OnEnable()
    {

        bulletAction?.Enable();
    }

    void OnDisable()
    {
        bulletAction?.Disable();
    }

    void Update()
    {

        if (bulletAction != null && bulletAction.IsPressed() && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        bullet.Changesprite((_status.Type, _status.Direction));
    }

    public void SetPlayerInstance(PlayerStatus status)
    {
        _status = status;
    }
}
