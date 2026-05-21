using DG.Tweening;
using UnityEngine;

public class InGameDirection : MonoBehaviour
{
    [Header("カメラ")]
    [SerializeField] private Camera _camera;
    [Header("何秒後に移動するか")]
    [SerializeField] private float _time;

    private bool _isMove = false;
    private void Start()
    {
        _camera.gameObject.transform.position = new Vector3(-7f, 0, -10);
    }

    private void Update()
    {
        _time -= Time.deltaTime;
        if (_time < 0 && !_isMove)
        {
            _isMove = true;
            _camera.transform.DOMove(new Vector3(0, 0, -10), 1f);
        }
    }
}
