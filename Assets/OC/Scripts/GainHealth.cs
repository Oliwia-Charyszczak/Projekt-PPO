using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainHealth : MonoBehaviour
{
    public HealthSystem healthSystem;
    public int heal = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            healthSystem.Heal(heal);
        }
        Destroy(gameObject);
    }
}
