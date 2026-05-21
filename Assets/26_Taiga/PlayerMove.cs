using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] InputActionAsset _action;
    [SerializeField] PlayerStatusExecute _player;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float minX = -8f;
    [SerializeField] private float maxX = 8f;
    [SerializeField] private float minY = -8f;
    [SerializeField] private float maxY = 8f;
    InputAction Move;
    InputAction _rotate;
    InputAction _change;
    public bool CanMove;

    void Awake()
    {
        Move = _action.FindActionMap("tg").FindAction("Move");
        _rotate = _action.FindActionMap("tg").FindAction("Rotate");
        _change = _action.FindActionMap("tg").FindAction("Change");
    }

    private void OnEnable()
    {
        _rotate.started += RotateMino;
        _change.started += ChangeMino;
    }

    private void OnDisable()
    {
        _rotate.started -= RotateMino;
        _change.started -= ChangeMino;
    }

    void Update()
    {
        if (!CanMove) return;
        Vector3 speed = Move.ReadValue<Vector2>();
        var a = transform.position;
        a += speed * Time.deltaTime * moveSpeed;
        transform.position = a;
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    void RotateMino(InputAction.CallbackContext ctx)
    {
        var dir = ctx.ReadValue<float>();
        _player?.ChangeDirection((int)Mathf.Sign(dir));
    }

    void ChangeMino(InputAction.CallbackContext ctx)
    {
        _player?.ChangeType(1);
    }
}
