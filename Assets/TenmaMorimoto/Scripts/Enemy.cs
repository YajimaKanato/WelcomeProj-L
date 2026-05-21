using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyStatus _status;
    [SerializeField] EnemyHPBar _hpBar;
    [SerializeField] private EnemyStatusBase _enemy;

    [SerializeField] private GameObject[] _unitPrefabs;
    [SerializeField] int _score = 100;
    [SerializeField] int _lifeTime = 10;
    EnemyGenerator _generator;
    IngameManager _gameManager;
    EnemyUnit[] _units;
    bool _isDead;
    public void InItt(EnemyGenerator generator)
    {
        _generator = generator;
        _status = new EnemyStatus(_enemy);
        _gameManager = FindFirstObjectByType<IngameManager>();
        var pos = new Vector3[] { new Vector3(5.5f, 3f, 0f), new Vector3(5.5f, 0f, 0f), new Vector3(5.5f, -3f, 0f) };

        _units = new EnemyUnit[3];
        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, _unitPrefabs.Length);
            var go = Instantiate(_unitPrefabs[index], pos[i], Quaternion.identity).GetComponent<EnemyUnit>();
            go?.SetParentEnemy(this);
            _units[i] = go;
        }
        StartCoroutine(LifeTime());
    }

    [ContextMenu("damage")]
    public void Damage()
    {
        if (_isDead) return;

        var hp = _status.Damage();
        _hpBar?.UpdateBar(_status.Rate);

        if (hp <= 0)
        {
            Dead();
        }
        transform.DOPunchPosition(new Vector3(0, 0.5f, 0), 0.8f, 10, 1f);

    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(_lifeTime);

        if (_isDead) yield break;

        Dead();
    }
    void Dead()
    {
        if (_isDead) return;

        _isDead = true;

        _generator?.GenerateEnemy();
        ScoreManager.Instance.UpdateScore(_score);
        _gameManager?.UpdateScore();
        foreach (var unit in _units)
        {
            if (unit && unit.gameObject)
                Destroy(unit.gameObject);
        }

        Destroy(gameObject);
    }
}
