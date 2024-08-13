using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float mSpeed = 3;
    public bool mIsMovingLeft = true;
    private Rigidbody2D _mRigidbody;
    
    void Start()
    {
        _mRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 velocity = _mRigidbody.velocity;
        Vector2 scale = transform.localScale;

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

        _mRigidbody.velocity = velocity;
        transform.localScale = scale;
    }
}
