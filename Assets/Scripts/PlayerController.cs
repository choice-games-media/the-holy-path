using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    public float jumpSpeed = 4f;
    public float groundRadiusCheck = 0.3f;
    public LayerMask layers;
    private SpriteRenderer _characterSpriteRender;
    private bool _jumpInput;
    private float _moveInput;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _characterSpriteRender = GetComponent<SpriteRenderer>();
    }
    
    /// <startedBy> Adam </startedBy>
    /// <summary>
    /// Checks for valid movement keys and flips the player based on the direction they are facing.
    /// </summary>
    private void Update()
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
    
    /// <startedBy> Adam </startedBy>
    /// <summary>
    /// Allows the player to jump based on their movement and jump speed, if and only if they are touching the ground.
    /// </summary>
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
    
    /// <startedBy> Adam </startedBy>
    /// <summary>
    /// For development use - displays the hitbox of the ground check.
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, groundRadiusCheck);
    }
    
    /// <startedBy> Adam </startedBy>
    /// <summary>
    /// Checks in a circle under the player if an object tagged Ground is collided with.
    /// </summary>
    /// <returns>Whether the player is touching the ground.</returns>
    private bool GroundCheck()
    {
        Collider2D hitCollider = Physics2D.OverlapCircle(
            transform.position,
            groundRadiusCheck,
            layers);

        if (hitCollider == null)
        {
            return false; // To fix an annoying Unity error
        }
        return hitCollider.CompareTag("Ground");
    }
}