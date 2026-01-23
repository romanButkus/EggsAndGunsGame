using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Vector2 _moveInput;
    private Animator _animator;
    private SpriteRenderer _sr;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        _moveInput = Vector2.ClampMagnitude(_moveInput, 1f);
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _moveInput * _speed;
    }

    private void Update()
    {
        Vector2 velocity = _rb.linearVelocity;

        _animator.SetBool("isRun", velocity.sqrMagnitude > 0.01);

        if (velocity.x != 0)
            _sr.flipX = velocity.x < 0;
    }
}
