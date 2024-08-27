using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    public float jumpSpeed = 4f;
    public float groundRadiusCheck = 0.3f;
    public LayerMask layers;
    Rigidbody2D _rb;
    float _moveInput;
    bool _jumpInput;
    private SpriteRenderer _characterSpriteRender;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _characterSpriteRender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _moveInput = Input.GetAxis("Horizontal");
        _jumpInput = Input.GetButton("Jump");

        if (_moveInput < 0)
        {
            _characterSpriteRender.flipX = false;
        }
        else if (_moveInput > 0)
        {
            _characterSpriteRender.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        Vector2 vel = _rb.velocity; // .velocity returns a temporary variable, so we can't directly set its value
        vel.x = _moveInput * movementSpeed;
        bool onGround = GroundCheck();
        if (_jumpInput && onGround)
        {
            vel.y = jumpSpeed;
        }

        _rb.velocity = vel;
    }

    bool GroundCheck()
    {
        Collider2D hitCollider = Physics2D.OverlapCircle(
            transform.position,
            groundRadiusCheck,
            layers);
        return hitCollider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, groundRadiusCheck);
    }
}