using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeLogic : MonoBehaviour
{
    [SerializeField] private float bounceForce;
    [SerializeField] private AudioSource jumpSound;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            jumpSound.Play();
            playerRb.velocity = new Vector2(playerRb.velocity.x, bounceForce);
            anim.SetBool("Bounce", true);
            StartCoroutine(WaitAnim());
        }
    }

    IEnumerator WaitAnim()
    {
        yield return new WaitForSeconds(2);
        anim.SetBool("Bounce", false);
    }
}
