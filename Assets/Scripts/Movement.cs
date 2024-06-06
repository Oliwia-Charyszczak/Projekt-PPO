using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D collide;
    private Animator anim;
    private SpriteRenderer sprite;

    private float dirX;
    private float wallDirection;
    private bool canWallJump = true;

    [SerializeField] private LayerMask jumpableGround;    //Powiazane z warstwa Ground
    [SerializeField] private LayerMask jumpableWall;      //Powiazane z warstwa Wall
    [SerializeField] private int bonusJump = 0;        // Ilosc datkowych skokow
    [SerializeField] private float wallSlideSpeed = 200f;  //O ile zwolnic opadanie na scianie
    [SerializeField] private bool isSliding = false;
    [SerializeField] private float moveSpeed = 7f;       // predkosc
    [SerializeField] private float jumpForce = 7f;       // wysokosc skoku
    [SerializeField] private AudioSource jumpSound;

    private enum MovementState { idle, walking, jumping, falling, slideRight, slideLeft }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collide = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && (IsOnGround() || bonusJump > 0))
        {
            if(bonusJump > 0)
            {
                bonusJump--;
            }
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if ((IsOnWallRight() || IsOnWallLeft()) && Input.GetButtonDown("Jump") && canWallJump)
        {
            isSliding = true;
            wallDirection = IsOnWallRight() ? -1f : 1f;
            jumpSound.Play();
            rb.velocity = new Vector2(wallDirection * moveSpeed, jumpForce);
            canWallJump = false;
        }

        else if (IsOnWallRight() || IsOnWallLeft())
        {
            isSliding = true;
            wallDirection = IsOnWallRight() ? -1f : 1f;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, - wallSlideSpeed));
        }

        if (IsOnGround() || (!IsOnWallRight() && !IsOnWallLeft()))
        {
            isSliding = false;
            canWallJump = true; 
        }

        else
        {
            isSliding = false;
        }
        UpdateAnimationState();
    }

    private bool IsOnGround()
        {
            return Physics2D.BoxCast(collide.bounds.center, collide.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        }

    private bool IsOnWallLeft()
        {
            return Physics2D.BoxCast(collide.bounds.center, collide.bounds.size, 0f, Vector2.left, .1f, jumpableWall);
        }
    private bool IsOnWallRight()
        {
            return Physics2D.BoxCast(collide.bounds.center, collide.bounds.size, 0f, Vector2.right, .1f, jumpableWall);
        }

    public void AddJump()
    {
        bonusJump++;
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.walking;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.walking;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f && !isSliding)
        {
            state = MovementState.falling;
        }

        if (isSliding = true && IsOnWallRight())
        {
            state = MovementState.slideRight;
        }

        else if (isSliding = true && IsOnWallLeft())
        {
            state = MovementState.slideLeft;
        }

        anim.SetInteger("AnimState", (int)state);
    }
}
