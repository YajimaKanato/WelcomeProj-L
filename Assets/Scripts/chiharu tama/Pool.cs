using UnityEngine;
using UnityEngine.Pool;     // オブジェクトプールを利用する際に必要

public class Pool : MonoBehaviour
{
    [Header("bullet")]
    [SerializeField] private GameObject _bullet;  // プールの中で管理したいオブジェクト
    [Header("bulletを出現させる場所")]
    [SerializeField] private Transform _burretPosition;

    private ObjectPool<GameObject> _pool;    // オブジェクトプールの変数を宣言

    public static Pool Instance;
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;


        // オブジェクトプールのインスタンスを生成
        _pool = new ObjectPool<GameObject>(
            CreatePooledItem,       // オブジェクト生成の際の処理
            OnTakeFromPool,         // オブジェクトを取り出す際の処理
            OnReturnedToPool,       // オブジェクトを返却する際の処理
            OnDestroyPoolObject,    // プールが上限を超えた場合の処理
            true,                   // すでにプール内にいるオブジェクトを返却した際にエラー表示するか
            2,                      // 初期のプールの容量
            10);                    // プール内オブジェクトの上限数
    }

    // オブジェクト生成の際の処理
    GameObject CreatePooledItem()
    {
        return Instantiate(_bullet);    // オブジェクトを生成してプールに渡す処理
    }

    // オブジェクトを取り出す際の処理
    void OnTakeFromPool(GameObject obj)
    {
        obj.SetActive(true);    // オブジェクトをアクティブにする処理
        obj.transform.position = _burretPosition.position;  // オブジェクトの座標を指定する処理
    }

    // オブジェクトを返却する際の処理
    public void OnReturnedToPool(GameObject obj)
    {
        obj.gameObject.SetActive(false);
    }

    // プールが上限を超えた場合の処理
    void OnDestroyPoolObject(GameObject obj)
    {
        Destroy(obj);    // オブジェクトを破壊する処理
    }

    public GameObject Get()
    {
        return _pool.Get();
    }
    public void Release(GameObject obj)
    {
        _pool.Release(obj);
    }
}

