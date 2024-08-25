using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    bool faceRight = false;
    SpriteRenderer characterSprite;
    public float movementSpeed = 2.0f;
    public float jumpSpeed = 4f;
    public float groundRadiusCheck = 0.3f;
    public LayerMask layers;

    Rigidbody2D _rb;
    float _moveInput;
    bool jumpInput = false;
    SpriteRenderer characterSpriteRend;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        characterSpriteRend = GetComponentInChildren<SpriteRenderer>(); 
    }

    void Update()
    {
        _moveInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetButton("jump");

        if (_moveInput < 0)
            faceRight = false;
        else if (_moveInput > 0)
            faceRight = true;

        characterSprite.flipX = faceRight;
    }

    private void FixedUpdate()
    {
        Vector2 vel = _rb.velocity;  // .velocity returns a temporary variable, so we can't directly set its value
        vel.x = _moveInput * movementSpeed;
        bool onGround = GroundCheck();
        if (jumpInput == true && onGround == true)
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
