using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    public Vector2 hitBoxSize;
    public Vector2 hitBoxPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckHit();
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            flip();
            currentPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            flip();
            currentPoint = pointB.transform;
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

    private void CheckHit()
    {
        // https://rider-support.jetbrains.com/hc/en-us/community/posts/11634372238098-NonAlloc-in-Unity-is-either-deprecated-or-ineffective
        // ReSharper disable once Unity.PreferNonAllocApi
        Collider2D[] colliders = Physics2D.OverlapBoxAll(
            transform.position + (Vector3)hitBoxPosition,
            new Vector3(
                hitBoxSize.x + 0.1f,
                hitBoxSize.y,
                0
            ),
            0
        );

        foreach (Collider2D collided in colliders)
        {
            if (collided.CompareTag("Player"))
            {
                Rigidbody2D collidedRb = collided.GetComponent<Rigidbody2D>();
                if (collidedRb != null)
                {
                    // If the player is falling
                    if (collidedRb.velocity.y < -0.2f)
                    {
                        Destroy(gameObject);
                        return;
                    }
                }

                PlayerHealth playerHealth = collided.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(1);
                }
            }
        }
    }
}
