using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float mSpeed = 3;
    public bool mIsMovingLeft = true;
    private Rigidbody2D _rigidbody;
    public LayerMask tileMask;
    private bool _isGrounded;
    public Vector2 hitBoxSize;
    public Vector2 hitBoxPosition;
    public Vector2 wallCheckHitBoxSize;
    private Collider2D _collider;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        Vector2 velocity = _rigidbody.velocity;
        Vector2 scale = transform.localScale;
        _isGrounded = CheckGround();

        if (_isGrounded)  // Prevents some weird sprite flip-flopping
        {
            if (mIsMovingLeft)
            {
                velocity.x = -mSpeed;
                scale.x = -1;  // Flips the sprite
            }
            else
            {
                velocity.x = mSpeed;
                scale.x = 1;
            }
        }
        CheckWalls(transform.position, scale.x);
        
        _rigidbody.velocity = velocity;
        transform.localScale = scale;
    }

    bool CheckGround()
    {
        RaycastHit2D feetHotbox = Physics2D.CircleCast(
            transform.position,  // Where to check (the position of the enemy)
            0.1f,  // How big the check should be
            Vector2.down,  // Direction of the check
            0.1f,  // Distance of the check
            tileMask  // Only check certain layers
        );

        return feetHotbox.collider != null;  // If the collider touches something, return true
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(
            transform.position + (Vector3)hitBoxPosition,  // Position of the hitbox
            new Vector3(hitBoxSize.x + 0.1f, hitBoxSize.y, 0)  // Size of the hitbox
                                                               // The z-axis is irrelevant, so it's 0
        );

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(
            new Vector2(
                transform.position.x + transform.localScale.x * (hitBoxSize.x / 2), 
                transform.position.y + hitBoxSize.x / 2
            ),
            wallCheckHitBoxSize
        );
    }

    void CheckWalls(Vector3 position, float direction)
    {
        _collider.enabled = false;
        Collider2D overlapBox = Physics2D.OverlapBox(
            new Vector2(position.x + direction * (hitBoxSize.x / 2),
                position.y + (hitBoxSize.y / 2)),
            wallCheckHitBoxSize,
            0,
            tileMask
        );
        _collider.enabled = true;

        if (overlapBox != null)
        {
            mIsMovingLeft = !mIsMovingLeft;
        }
    }
}
