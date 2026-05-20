using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyStatus _status;
    [SerializeField] private EnemyStatusBase _enemy;

    [SerializeField] private GameObject[] _unitPrefabs;

    private void Start()
    {
        InItt();
    }

    void InItt ()
    {
        _status = new EnemyStatus(_enemy);
    }

    [ContextMenu("damage")]
    public void Damage()
    {
       var _hp = _status.Damage();

        if (_hp <= 0 )
        {
            Destroy(gameObject);
        }

    }


    private void OnEnable()
    {
        int index = Random.Range(0, _unitPrefabs.Length);
        GameObject selectedPrefab = _unitPrefabs[index];



        Instantiate(selectedPrefab, new Vector3(5.5f, 3f, 0f),Quaternion.identity);
        Instantiate(selectedPrefab, new Vector3(5.5f, 0f, 0f), Quaternion.identity);
        Instantiate(selectedPrefab, new Vector3(5.5f, -3f, 0f), Quaternion.identity);

    }

}
