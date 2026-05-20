using UnityEngine;
using DG.Tweening;

public class EnemyBullet_Straight : EnemyBullet_Base
{
    void Start()
    {
        BulletMovement();
    }

    void Update()
    {

    }


    public override void BulletMovement()
    {
        transform.DOLocalMoveX(-10f, 1f)
            .SetEase(Ease.Linear)
           .SetLoops(-1, LoopType.Incremental)
           .SetLink(gameObject);

        Debug.Log("移動");
    }


}
