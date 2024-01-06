using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D collide;

    [SerializeField] private LayerMask jumpableGround;    //Powi¹zane z warstw¹ Ground
    [SerializeField] private LayerMask jumpableWall;      //Powi¹zane z warstw¹ Wall

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collide = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsOnGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if ((IsOnWallRight() || IsOnWallLeft()) &&  Input.GetButtonDown("Jump"))
        {
            Debug.Log("jebac disa");
            float wallDirection = IsOnWallRight() ? -1f : 1f;
            rb.velocity = new Vector2(moveSpeed, jumpForce);
        }
    }

    private bool IsOnGround()
    {
        return Physics2D.BoxCast(collide.bounds.center, collide.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private bool IsOnWallLeft ()
    {
        return Physics2D.BoxCast(collide.bounds.center, collide.bounds.size, 0f, Vector2.left, .1f, jumpableWall);
        
    }
    private bool IsOnWallRight()
    {
        return Physics2D.BoxCast(collide.bounds.center, collide.bounds.size, 0f, Vector2.right, .1f, jumpableWall);

    }
}
