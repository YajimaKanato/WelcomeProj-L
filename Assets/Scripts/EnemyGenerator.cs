using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] Enemy[] _enemies;
    public void GenerateEnemy()
    {
        var rand = Random.Range(0, _enemies.Length);
        var go = Instantiate(_enemies[rand], transform.position, transform.rotation);
        go.InItt(this);
    }
}
