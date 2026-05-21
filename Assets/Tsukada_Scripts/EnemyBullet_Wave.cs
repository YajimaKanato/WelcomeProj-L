using UnityEngine;
using DG.Tweening;

public class EnemyBullet_Wave : EnemyBullet_Base
{

    void Start()
    {
        BulletMovement();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void BulletMovement()
    {
        float Posx = gameObject.transform.position.x;
        float Posy = gameObject.transform.position.y;

        transform.DOLocalMoveX(-8f, 2.5f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Incremental)
            .SetLink(gameObject);

        transform.DOLocalMoveY(2f, 0.8f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo)
            .SetLink(gameObject);


        //transform.DOLocalPath(
        //    new[]
        //    {
        //        new Vector3(Posx, Posy, 0f),
        //        new Vector3(Posx + 3f, Posy + 3f, 0f),
        //        new Vector3(Posx + 6f, Posy -3f, 0f),
        //        new Vector3(Posx, Posy, 0f)
        //    },
        //    3f, PathType.CatmullRom);
    }
}