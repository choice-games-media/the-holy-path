using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    Rigidbody2D _rb;
    float _moveInput;
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _moveInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Vector2 velocity = _rb.velocity;  // .velocity returns a temporary variable, so we can't directly set its value
        velocity.x = _moveInput * movementSpeed;
        _rb.velocity = velocity;
    }
}
