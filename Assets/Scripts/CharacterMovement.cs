using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    public Rigidbody2D rb;
    private float _moveInput;

    private void Awake()
    { 
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }
    private void Update()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(_moveInput * speed, rb.linearVelocity.y);
    }
}