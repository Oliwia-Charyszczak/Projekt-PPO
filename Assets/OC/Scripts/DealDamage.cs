using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public HealthSystem healthSystem;
    public int damage = 1;
    public float delayBeforeNextDamage = 3f;

    private bool isPlayerInContact = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInContact = true;
            InvokeRepeating("DealRepeatedDamage", 0f, delayBeforeNextDamage);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInContact = false;
            CancelInvoke("DealRepeatedDamage");
        }
    }

    private void DealRepeatedDamage()
    {
        if (isPlayerInContact)
        {
            healthSystem.TakeDamage(damage);
        }
    }
}
