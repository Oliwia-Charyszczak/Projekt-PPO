using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D collide;

    [SerializeField] private LayerMask jumpableGround;    //Powiazane z warstwa Ground
    [SerializeField] private LayerMask jumpableWall;      //Powiazane z warstwa Wall
    [SerializeField] private int bonusJump = 0;        // Ile dodatkowych skokow
    [SerializeField] private float wallSlideSpeed = 200f;  //O ile zwolnic na slidzie
    [SerializeField] private bool isSliding = false;
    [SerializeField] private float moveSpeed = 7f;       // #SPEED
    [SerializeField] private float jumpForce = 7f;       // NBA?
    [SerializeField] private float bonus = 20f;          // O ile przyspieszyc na 5 s
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collide = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && (IsOnGround() || bonusJump > 0))
        {
            if(bonusJump > 0)
            {
                bonusJump--;
            }
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if ((IsOnWallRight() || IsOnWallLeft()) && Input.GetButtonDown("Jump"))
        {
            isSliding = true;
            Debug.Log("jebac disa");
            float wallDirection = IsOnWallRight() ? -1f : 1f;
            rb.velocity = new Vector2(moveSpeed, jumpForce);
        }

        else if (IsOnWallRight() || IsOnWallLeft())
        {
            isSliding = true;
            Debug.Log("jebac disa");
            float wallDirection = IsOnWallRight() ? -1f : 1f;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, - wallSlideSpeed));
        }
        else
        {
            isSliding = false;
        }
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
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "reCharge")
        {
            
            Debug.Log("Jeszcze jak");
            //StartCoroutine(JumpCoroutine(other));
        }
        else if(other.tag == "Speed")
        {
            Debug.Log("kachow");
            Destroy(other.gameObject);
            StartCoroutine(SpeedCoroutine());
        }
        
    }
    IEnumerator SpeedCoroutine()
    {
        moveSpeed += bonus;
        yield return new WaitForSeconds(5);
        moveSpeed -= bonus;
    }
    IEnumerator JumpCoroutine(GameObject other)
    {
        bonusJump++;
        other.SetActive(false);
        yield return new WaitForSeconds(8);
        other.SetActive(true);
    }
}