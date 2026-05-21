using UnityEngine;
using DG.Tweening;

public class EnemyBullet_Following : EnemyBullet_Base
{
    public Transform target; // 追従する目標
    //public float speed = 5f;
    private Tweener tween;

    void Start()
    {
        target = GameObject.Find("Player").transform;
        BulletMovement();
    }

    void Update()
    {

        if (transform.position.x <= target.position.x + 5)
        {
            return;
        }
        else
        {
            tween.ChangeEndValue(target.position, true);
        }
    }

    public override void BulletMovement()
    {
        tween = transform.DOMove(target.position, 1f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Incremental)
            .SetLink(gameObject);
    }
}
