using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    public Rigidbody2D rb;
    private float _moveInput;
    private bool _facingRight = true;

    private void Awake()
    { 
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private void Update()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");

        if (_moveInput > 0 && !_facingRight || _moveInput < 0 && _facingRight)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(_moveInput * speed, rb.linearVelocity.y);
    }

    private void Flip()
    {
        _facingRight = !_facingRight;

        var currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
}