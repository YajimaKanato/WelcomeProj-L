using UnityEngine;

[CreateAssetMenu(fileName = "Bullets", menuName = "Scriptable Objects/Bullets")]
public class Bullets : ScriptableObject
{
    [SerializeField] EnemyBullet_Base[] _bullets;

    public EnemyBullet_Base[] Bullet => _bullets;
}
