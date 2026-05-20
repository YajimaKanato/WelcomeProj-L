using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyStatus _status;
    [SerializeField] private EnemyStatusBase _enemy;

    [SerializeField] private GameObject[] _unitPrefabs;
    [SerializeField] int _lifeTime = 10;
    EnemyGenerator _generator;

    public void InItt(EnemyGenerator generator)
    {
        _generator = generator;
        _status = new EnemyStatus(_enemy);
        StartCoroutine(LifeTime());
    }

    [ContextMenu("damage")]
    public void Damage()
    {
        var _hp = _status.Damage();

        if (_hp <= 0)
        {
            _generator?.GenerateEnemy();
            Destroy(gameObject);
        }

    }


    private void OnEnable()
    {
        var pos = new Vector3[] { new Vector3(5.5f, 3f, 0f), new Vector3(5.5f, 0f, 0f), new Vector3(5.5f, -3f, 0f) };

        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, _unitPrefabs.Length);
            Instantiate(_unitPrefabs[index], pos[i], Quaternion.identity);
        }
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        _generator?.GenerateEnemy();
        Destroy(gameObject);
    }
}
