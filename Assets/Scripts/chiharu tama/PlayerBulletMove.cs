using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMove : MonoBehaviour
{
    [Header("Tag")]
    [SerializeField] private string _tag;
    [Header("UnitList")]
    [SerializeField] private UnitList _unitlist;

    private Dictionary<ConditionSetting, Sprite> _dic = new Dictionary<ConditionSetting, Sprite>();
  
    private float playerBulletSpeed = 0.05f;   // 弾のスピードを決める変数
    private Renderer _renderer;
    private void Start()
    {
        foreach (var item in _unitlist.UnitsList)
        {
            _dic.TryAdd(item.Conditions, item.UnitSprite);
        }
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        transform.Translate(playerBulletSpeed, 0, 0); // X座標をプラスに動く
        if (!_renderer.isVisible)
            Pool.Instance.Release(this.gameObject);
    }

    private void Changesprite(ConditionSetting c)
    {
        var sprite = _dic[c];
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _tag)
        {
            Pool.Instance.Release(this.gameObject);
        }
    }
}