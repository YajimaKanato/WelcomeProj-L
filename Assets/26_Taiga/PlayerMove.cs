using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]InputActionAsset _action;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float minX = -8f;
    [SerializeField] private float maxX = 8f;
    [SerializeField] private float minY = -8f;
    [SerializeField] private float maxY = 8f;
    InputAction Move;
    private Rigidbody2D rb2d;
    private float moveInput;

    void Start()
    {
        Move = _action.FindActionMap("tg").FindAction("Move");
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 speed = Move.ReadValue<Vector2>();
        var a = transform.position;
        a += speed * Time.deltaTime * moveSpeed; 
        transform.position = a;
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
