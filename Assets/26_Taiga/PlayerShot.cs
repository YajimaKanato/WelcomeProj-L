using UnityEngine;
using UnityEngine.InputSystem; // 新しいInput Systemを使用

public class PlayerShot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;  // 弾プレハブ
    [SerializeField] private Transform spawnPoint;      // 弾の出る位置
    [SerializeField] private float bulletSpeed = 10f;   // 弾速
    [SerializeField] private float fireRate = 0.5f;     // 発射間隔

    private float nextFireTime = 0f;                    // 次に撃てる時刻

    [SerializeField] private InputActionAsset _action;
    private InputAction bulletAction;

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
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = spawnPoint.right * bulletSpeed;
        }
    }
}
