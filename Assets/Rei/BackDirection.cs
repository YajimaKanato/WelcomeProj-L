using UnityEngine;

public class BackDirection : MonoBehaviour
{
    [Header("動かす速さ")]
    [SerializeField] private float _speed;

    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        transform.position = new Vector2(0, 0);
    }

    private void Update()
    {
        if (_renderer.isVisible)
            transform.position = new Vector2(transform.position.x + _speed, 0);
        else
            transform.position = new Vector2(0, 0);
    }
}
