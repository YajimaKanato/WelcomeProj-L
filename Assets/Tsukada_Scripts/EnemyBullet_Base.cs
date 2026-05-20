using UnityEngine;
using DG.Tweening;

public abstract class EnemyBullet_Base : MonoBehaviour
{
    

    public abstract void BulletMovement();          //弾幕の挙動

    
    public void OnCollisionEnter2D(Collision2D collision)   //Playerに衝突したら削除
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    public void OnBecameInvisible()     //画面外に出たら削除
    {
        Destroy(gameObject);
    }
}
