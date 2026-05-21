using NUnit.Framework.Internal;
using UnityEngine;

public class PlayerBulletMove : MonoBehaviour
{
    [Header("Tag")]
    [SerializeField] private string _tag;
    [Header("UnitList")]
    [SerializeField] private UnitList _unitlist;
    [SerializeField] GameObject _effect;

    [SerializeField] private float playerBulletSpeed = 0.3f;   // 弾のスピードを決める変数
    private Renderer _renderer;
    private bool _isRelease = false;

    public MinoType Type { get; private set; }
    public MinoDirection Direction { get; private set; }

    void Update()
    {
        transform.Translate(playerBulletSpeed, 0, 0); // X座標をプラスに動く
        if (!_renderer.isVisible)
            Pool.Instance.Release(this.gameObject);
    }

    public void Changesprite((MinoType, MinoDirection) c)
    {
        Sprite sprite = null;
        foreach (var item in _unitlist.UnitsList)
        {
            if (c == (item.Conditions.Type, item.Conditions.MyDirection))
            {
                sprite = item.UnitSprite;
                break;
            }
        }
        Type = c.Item1;
        Direction = c.Item2;
        _renderer = GetComponent<Renderer>();
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isRelease) return;
        _isRelease = true;
        if (collision.gameObject.tag == _tag)
        {
            Instantiate(_effect, transform.position, Quaternion.identity);
            Pool.Instance.Release(this.gameObject);
        }
    }
}